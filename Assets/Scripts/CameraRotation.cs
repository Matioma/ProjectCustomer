using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public event Action OnSelectPlanet;

    [SerializeField]
    Planet SelectedPlanet;

    [SerializeField]
    float RotationSensitivity = 200;
    [SerializeField]
    float ScrollingSpeed = 500;



    bool MousePressed = false;

    float MouseXAxis;
    float MouseYAxis;
    float ScrollAxis;


    private void Awake()
    {
        transform.LookAt(SelectedPlanet.transform);
    }

    void LateUpdate()
    {
        readInput();
        zoomingIn();
        rotateAroundThePlanet();
    }

    void selectPlanet()
    {
        RaycastHit hitResult;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity))
        {
            Planet hitPlanet = hitResult.transform.GetComponent<Planet>();

            if (hitPlanet != null && hitPlanet!=SelectedPlanet) {
                SelectedPlanet = hitPlanet;
                transform.LookAt(SelectedPlanet.transform);
                zoomAsCloseAsPossible();
                OnSelectPlanet?.Invoke();
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
            selectPlanet();
            MousePressed = true;
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


