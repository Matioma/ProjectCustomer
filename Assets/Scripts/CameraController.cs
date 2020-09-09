using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum CameraState { 
    OnPlanet,
    WatchingWorld
}

public class CameraController : MonoBehaviour
{
    static CameraController _instance;

    public static CameraController Instance {
        get { return _instance; }
        set {
            if (_instance != null) {
                Debug.LogError(" Only one Camera Controller allowed, it is being deleted");
                Destroy(value.gameObject);
            }
            else
            {
                _instance = value;
            }
        }
    }

    [SerializeField, Tooltip("Position of the camera when zoomed out to view the world")]
    Transform worldViewTransform;

    MyTransform initialTransform;
    MyTransform targetTransform;
    float progress=0;

    [SerializeField, Range(0,10), Tooltip("Time required for the camera to zoom in to a planet")]
    float transitionTime=1.0f;

    bool isCameraTransitioning;

    CameraState cameraState = CameraState.OnPlanet;

    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;
    public event Action OnSelectZone;

    [SerializeField]
    Planet SelectedPlanet;
    [SerializeField]
    ZoneSelection SelectedZone;

    public Planet GetSelectedPlanet() {
        return SelectedPlanet;
    }

    [SerializeField, Tooltip("Sensitivity of the camera rotating around planets")]
    float RotationSensitivity = 50;

    bool MousePressed;
    float MouseXAxis;
    float MouseYAxis;
    float ScrollAxis;

    Vector2 movement;
    Vector2 rotationYSpeed;

    [SerializeField, Range(0,1), Tooltip("Increase the value to make the planet stop slower")]
    float planetInertia=0.95f;



    [SerializeField, Tooltip("How much movement is allowed until the user is still selecting the planet")]
    float maxMovementMagnitute = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        selectPlanet(SelectedPlanet);
    }
    void readInput()
    {
        ScrollAxis = Input.GetAxis("Mouse ScrollWheel");
        MouseXAxis = Input.GetAxis("Mouse X");
        MouseYAxis = Input.GetAxis("Mouse Y");

        RegisterMouseMovements();

        if (Input.GetMouseButtonDown(0))
        {
            MousePressed = isHitingPlanet();
            //MousePressed = true;
            ResetMouseMovements();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (movement.sqrMagnitude <= maxMovementMagnitute)
            {
                TrySelectZone();
            }

            if (cameraState == CameraState.WatchingWorld)
            {
                TrySelectPlanet();
            }
            MousePressed = false;
        }
    }
    void Update()
    {
        readInput();
        if (isCameraTransitioning)
        {
            LerpTransform(initialTransform, targetTransform, transitionTime);
        }
        else {
            zoomingCamera();
            rotateAroundThePlanet();
        }
    }
    void TrySelectPlanet(){
        RaycastHit hitResult;
        LayerMask layerMask = LayerMask.GetMask("Planet");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity, layerMask))
        {
            Planet newSelectedPlanet = hitResult.transform.GetComponent<Planet>();

            // If Clicked on a planet and it is different from already Selected Planet
            if (newSelectedPlanet != null && newSelectedPlanet!=SelectedPlanet)
            {
                selectPlanet(newSelectedPlanet);
            }
        }
    }
    private void selectPlanet(Planet newSelectedPlanet)
    {
        deselectLastPlanet();
        SelectedPlanet = newSelectedPlanet;
        ZoomToPlanet();

        SelectedPlanet.GetComponent<Planet>().Select(); //Inform the planet that it was selected
        OnSelectPlanet?.Invoke();

        cameraState = CameraState.OnPlanet;
    }
    private void deselectLastPlanet() {
        deselectLastZone();
        if (SelectedPlanet != null)
        {
            SelectedPlanet.GetComponent<Planet>().Deselect();
            OnDeselectPlanet?.Invoke();
        }
        SelectedPlanet = null;
    }
    private void deselectLastZone() {
        //If any zone was selected
        if (SelectedZone != null)
        {
            //Delelect it
            SelectedZone.GetComponent<ZoneSelection>().Deselect();
        }
        SelectedZone = null;
    }
    void TrySelectZone() {
        RaycastHit hitResult;
        LayerMask layerMask = LayerMask.GetMask("Continent", "Planet");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity, layerMask))
        {
            ZoneSelection newSelectedZone = hitResult.transform.GetComponent<ZoneSelection>();


            // If Clicked on a zone and it is different from already Selected Zone
            if (newSelectedZone != null && newSelectedZone != SelectedPlanet)
            {
                // Make sure the user does not select zone From Another Planet
                if (SelectedPlanet == null || newSelectedZone.GetComponentInParent<Planet>() != SelectedPlanet)
                {
                    return;
                }

                //Deselect Previous Zone
                if (SelectedZone != null)
                {
                    SelectedZone.GetComponent<ZoneSelection>().Deselect();
                }

                
                SelectedZone = newSelectedZone;
                newSelectedZone.GetComponent<ZoneSelection>().Select();

                //hitResult.normal
                ZoomToRegion(hitResult);


                OnSelectZone?.Invoke();
            }
            else if(newSelectedZone == null)
            {
                deselectLastZone();
            }
        }
       
    }
    void ResetMouseMovements() {
        movement = new Vector2(0, 0);
    }
    void RegisterMouseMovements() {
        movement += new Vector2(Math.Abs(MouseXAxis), Math.Abs(MouseYAxis));
    }

    bool isHitingPlanet() {
        RaycastHit hitResult;
        LayerMask layerMask = LayerMask.GetMask("Planet");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity, layerMask))
        {
            return true;
        }
        return false;
    }

    void zoomingCamera() {
        if(ScrollAxis <0){
            deselectLastZone();
            deselectLastPlanet();
           
            StartTransitionTo(new MyTransform(worldViewTransform));
            cameraState = CameraState.WatchingWorld;
        }
    }
    void rotateAroundThePlanet()
    {

        if (SelectedPlanet == null) {
            return;
        }

        if (MousePressed)
        {
            rotationYSpeed.x = MouseXAxis * RotationSensitivity;
            rotationYSpeed.y = MouseYAxis * RotationSensitivity;
        }
        else{
            rotationYSpeed.x *= planetInertia;
            rotationYSpeed.y = 0;
        }

        if (rotationYSpeed.sqrMagnitude > 0) {
            transform.RotateAround(SelectedPlanet.transform.position, transform.up, rotationYSpeed.x);
            transform.RotateAround(SelectedPlanet.transform.position, transform.right, -rotationYSpeed.y);

            //Make Sure that Z axis rotation is 0
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
    /// <summary>
    /// Zooms the Camera To the selected Planet
    /// </summary>
    void ZoomToPlanet() {
        Vector3 directionTowardsPlayer = (transform.position - SelectedPlanet.transform.position).normalized;

        Vector3 newPosition = SelectedPlanet.transform.position + directionTowardsPlayer * SelectedPlanet.GetDistance();
        Quaternion lookAtRotation = Quaternion.LookRotation((SelectedPlanet.transform.position - transform.position ).normalized);


        //Struct info about target transform
        MyTransform targetTransform = new MyTransform(newPosition, lookAtRotation, new Vector3(1,1,1));
        StartTransitionTo(targetTransform);
    }
    void ZoomToRegion(RaycastHit hitResult) {
        var continentDirection =hitResult.transform.GetComponent<ContinentDirection>();

        Vector3 directionVector = hitResult.normal;
        if (continentDirection != null) {
            directionVector = continentDirection.getDirection().normalized;
        }

        Vector3 position = SelectedPlanet.transform.position + directionVector * SelectedPlanet.GetDistance();
        Quaternion lookAtRotation = Quaternion.LookRotation((SelectedPlanet.transform.position - position).normalized);

        MyTransform targetTransform = new MyTransform(position, lookAtRotation, new Vector3(1, 1, 1));
        StartTransitionTo(targetTransform);
    }
    void StartTransitionTo(MyTransform target)
    {
        initialTransform =new MyTransform(transform);
        targetTransform = target;
        progress = 0;
        isCameraTransitioning = true;
    }
    void LerpTransform(MyTransform initialTransform, MyTransform targetTransform, float speed) {
        progress += 1/speed* Time.deltaTime;

        transform.position = Vector3.Lerp(initialTransform.position, targetTransform.position, progress);
        transform.rotation = Quaternion.Lerp(initialTransform.rotation, targetTransform.rotation, progress);

        if (progress >= 1f) {
            SetCameraTransorm(targetTransform);
            isCameraTransitioning = false;
        }
    }
    void SetCameraTransorm(MyTransform target)
    {
        this.transform.position = target.position;
        this.transform.rotation = target.rotation;
        transform.localScale = target.localScale;
    }
}
