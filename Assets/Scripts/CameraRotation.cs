using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    static CameraRotation _instance;

    public static CameraRotation Instance {
        get { return _instance; }
        set {
            if (_instance != null) {
                Debug.LogError("Second Camera Rotation Created, it is being deleted");
                Destroy(value.gameObject);
            }
            else
            {
                _instance = value;
            }
        }
    
    }

    [SerializeField]
    Transform worldViewTransform;

    MyTransform initialTransform;
    MyTransform targetTransform;
    float progress=0;

    [SerializeField, Range(0,10)]
    float transitionTime=1.0f;

    bool isCameraTransitioning;






    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;
    public event Action OnSelectZone;



    [SerializeField]
    PlanetManager SelectedPlanet;
    [SerializeField]
    public Zone SelectedZone;

    public Zone GetSelectedZone() {
        return SelectedZone;
    }
    public PlanetManager GetSelectedPlanet()
    {
        return SelectedPlanet;
    }

    [SerializeField]
    float RotationSensitivity = 200;
    [SerializeField]
    float ScrollingSpeed = 500;

    bool MousePressed;


    float MouseXAxis;
    float MouseYAxis;
    float ScrollAxis;


    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        selectPlanet(SelectedPlanet);
    }

    void Update()
    {
        if (isCameraTransitioning)
        {
            LerpTransform(initialTransform, targetTransform, transitionTime);
        }
        else {
            readInput();
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
            PlanetManager newSelectedPlanet = hitResult.transform.GetComponent<PlanetManager>();

            // If Clicked on a planet and it is different from already Selected Planet
            if (newSelectedPlanet != null && newSelectedPlanet!=SelectedPlanet)
            {
                selectPlanet(newSelectedPlanet);
            }
        }
    }

    private void selectPlanet(PlanetManager newSelectedPlanet)
    {
        //Deselect pevious planet if any planet was selected
        if (SelectedPlanet != null)
        {
            SelectedPlanet.GetComponent<PlanetManager>().Deselect();
            OnDeselectPlanet?.Invoke();
        }
        SelectedPlanet = newSelectedPlanet;
       
        //transform.LookAt(SelectedPlanet.transform);


        //If any zone was selected
        if (SelectedZone != null)
        {
            //Delelect it
            SelectedZone.GetComponent<ZoneSelection>().Deselect();
        }
        zoomAsCloseAsPossible();

        
        SelectedPlanet.GetComponent<PlanetManager>().Select(); //Inform the planet that it was selected
        OnSelectPlanet?.Invoke();
    }
    private void deselectPlanet() {
        deselectZone();
        if (SelectedPlanet != null)
        {
            SelectedPlanet.GetComponent<PlanetManager>().Deselect();
            OnDeselectPlanet?.Invoke();
        }
        SelectedPlanet = null;
    }
    private void deselectZone() {
        //If any zone was selected
        if (SelectedZone != null)
        {
            //Delelect it
            SelectedZone.GetComponent<ZoneSelection>().Deselect();
        }
    }
    void TrySelectZone() {
        RaycastHit hitResult;
        LayerMask layerMask = LayerMask.GetMask("Continent");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity, layerMask))
        {
            Zone newSelectedZone = hitResult.transform.GetComponent<Zone>();

            // If Clicked on a zone and it is different from already Selected Zone
            if (newSelectedZone != null && newSelectedZone != SelectedPlanet)
            {
                if (newSelectedZone.PlanetContainingContinent() != null && newSelectedZone.PlanetContainingContinent() != SelectedPlanet)
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

                //MoveCameraToZone();
                OnSelectZone?.Invoke();
            }
        }
    }

    void readInput()
    {
        ScrollAxis = Input.GetAxis("Mouse ScrollWheel");
        MouseXAxis = Input.GetAxis("Mouse X");
        MouseYAxis = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            MousePressed = true;
            TrySelectPlanet();
            TrySelectZone();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MousePressed = false;
        }
    }

    void zoomingCamera() {
        if(ScrollAxis <0){
            deselectPlanet();
            StartTransition(new MyTransform(worldViewTransform));
        }
    }

    void rotateAroundThePlanet()
    {
        if (MousePressed)
        {

            transform.RotateAround(SelectedPlanet.transform.position,transform.up, MouseXAxis* RotationSensitivity);
            transform.RotateAround(SelectedPlanet.transform.position, transform.right, -MouseYAxis * RotationSensitivity);

            //Make Sure that Z axis rotation is 0
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }

    void zoomAsCloseAsPossible() {
        Vector3 directionTowardsPlayer = (transform.position - SelectedPlanet.transform.position).normalized;


        Vector3 position = SelectedPlanet.transform.position + directionTowardsPlayer * SelectedPlanet.GetDistance();
        Quaternion lookAtRotation = Quaternion.LookRotation((SelectedPlanet.transform.position - transform.position ).normalized);



        MyTransform myTransform = new MyTransform(position, lookAtRotation, new Vector3(1,1,1));


        StartTransition(myTransform);
       
    }

    void StartTransition(MyTransform target)
    {

        initialTransform =new MyTransform(transform);
        targetTransform = target;
        progress = 0;
        isCameraTransitioning = true;
    }
  



    void LerpTransform(MyTransform initialTransform, MyTransform finalTransform, float speed) {

        progress += 1/speed* Time.deltaTime;

        transform.position = Vector3.Lerp(initialTransform.position, finalTransform.position, progress);
        transform.rotation = Quaternion.Lerp(initialTransform.rotation, finalTransform.rotation, progress);

        if (progress >= 1f) {
            transitionTo(finalTransform);
            isCameraTransitioning = false;
        }
    }

    void transitionTo(MyTransform target)
    {
        this.transform.position = target.position;
        this.transform.rotation = target.rotation;
        transform.localScale = target.localScale;
    }
}

struct MyTransform {
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 localScale;

    
    public MyTransform(Vector3 position, Quaternion rotation, Vector3 scale){
        this.position = position;
        this.rotation = rotation;
        this.localScale = scale;
    }

    public MyTransform(Transform tranform) {
        this.position = tranform.position;
        this.rotation = tranform.rotation;
        this.localScale = tranform.localScale;
    }
}


