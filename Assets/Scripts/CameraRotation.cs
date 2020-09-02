using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
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


    [SerializeField]
    float maxCloseUp = 100;



    public event Action OnSelectPlanet;
    private void Awake()
    {
        transform.LookAt(SelectedPlanet.transform);

        OnSelectPlanet += () =>
        {
            transform.LookAt(SelectedPlanet.transform);
        };
    }

    void Update()
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

            Debug.Log(hitPlanet.transform.name);

            if (hitPlanet != null && hitPlanet!=SelectedPlanet) {
               
                SelectedPlanet = hitPlanet;
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
        if (ScrollAxis > 0)
        {
            if ((transform.position - SelectedPlanet.transform.position).sqrMagnitude <= maxCloseUp * maxCloseUp)
            {
                return;
            }
            else
            {
                transform.position += transform.forward * ScrollAxis * ScrollingSpeed;
            }
        }
        else
        {
            transform.position += transform.forward * ScrollAxis * ScrollingSpeed;
        }
    }

    void rotateAroundThePlanet()
    {
        if (MousePressed)
        {
            transform.RotateAround(SelectedPlanet.transform.position,transform.up, MouseXAxis* RotationSensitivity);
            transform.RotateAround(SelectedPlanet.transform.position, transform.right, -MouseYAxis * RotationSensitivity);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }

}
