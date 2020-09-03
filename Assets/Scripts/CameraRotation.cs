using System;
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



    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;
    public event Action OnSelectZone;



    [SerializeField]
    Planet SelectedPlanet;
    [SerializeField]
    public Zone SelectedZone;

    public Zone GetSelectedZone() {
        return SelectedZone;
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

        transform.LookAt(SelectedPlanet.transform);
        
    }

    void Update()
    {
        readInput();
        zoomingIn();
        rotateAroundThePlanet();
    }


    
    void selectPlanet(){
        RaycastHit hitResult;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity))
        {
            Planet newSelectedPlanet = hitResult.transform.GetComponent<Planet>();

            // If Clicked on a planet and it is different from already Selected Planet
            if (newSelectedPlanet != null && newSelectedPlanet!=SelectedPlanet) {

                //Deselect the planet if any planet was selected
                if (SelectedPlanet != null) {
                    SelectedPlanet.GetComponent<PlanetManager>().Deselect();
                    OnDeselectPlanet?.Invoke();
                }

                SelectedPlanet = newSelectedPlanet;
               
                transform.LookAt(SelectedPlanet.transform);

                if (SelectedZone != null)
                {
                    SelectedZone.GetComponent<ZoneSelection>().Deselect();
                }
                zoomAsCloseAsPossible();

                SelectedPlanet.GetComponent<PlanetManager>().Select();
                OnSelectPlanet?.Invoke();
            }
        }
    }

    void selectZone() {
        RaycastHit hitResult;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity))
        {
            Zone newSelectedZone = hitResult.transform.GetComponent<Zone>();

            // If Clicked on a zone and it is different from already Selected Zone
            if (newSelectedZone != null && newSelectedZone != SelectedPlanet)
            {

                //Deselect Previous Zone
                if (SelectedZone != null)
                {
                    SelectedZone.GetComponent<ZoneSelection>().Deselect();
                }

                SelectedZone = newSelectedZone;
                newSelectedZone.GetComponent<ZoneSelection>().Select();

                MoveCameraToZone();
                OnSelectZone?.Invoke();
            }
        }
    }


    void MoveCameraToZone() {
        if (SelectedPlanet == null || SelectedZone == null) {
            return;
        }

        float DistancePlayerToPlanet = (transform.position - SelectedPlanet.transform.position).magnitude;

        Vector3 directionFromPlanetToZone = (SelectedZone.transform.position - SelectedPlanet.transform.position).normalized;
        transform.position = SelectedPlanet.transform.position + directionFromPlanetToZone * DistancePlayerToPlanet;
        transform.LookAt(SelectedPlanet.transform);
    }

    void readInput()
    {
        ScrollAxis = Input.GetAxis("Mouse ScrollWheel");
        MouseXAxis = Input.GetAxis("Mouse X");
        MouseYAxis = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            MousePressed = true;
            selectPlanet();
            selectZone();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MousePressed = false;
        }
    }

    void zoomingIn() {
        transform.position += transform.forward * ScrollAxis * ScrollingSpeed;

        if (ScrollAxis > 0)
        {
            if ((transform.position - SelectedPlanet.transform.position).sqrMagnitude < SelectedPlanet.GetDistance() * SelectedPlanet.GetDistance())
            {
                zoomAsCloseAsPossible();
            }
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
        transform.position = SelectedPlanet.transform.position + directionTowardsPlayer * SelectedPlanet.GetDistance();
    }
}


