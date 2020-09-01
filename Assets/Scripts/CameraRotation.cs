using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float RotationSensitivity = 200;

    bool MousePressed = false;

    float MouseXAxis;
    float MouseYAxis;


    Quaternion initialRotation;
    Vector3 positionOffset;
    Vector3 initialPosition;

    private void Awake()
    {
        transform.LookAt(target);

        initialPosition = this.transform.position;
        initialRotation = transform.rotation;
        positionOffset = transform.position - target.position;
    }

    void Update()
    {
        




        ReadInput();
        RotateAroundThePlanet();
    }

    void ReadInput()
    {
        MouseXAxis = Input.GetAxis("Mouse X");
        MouseYAxis = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            //MousePressed = IsPlanetPressed();
            MousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MousePressed = false;
        }
    }


    void RotateAroundThePlanet()
    {
        if (MousePressed)
        {
            //target.transform.Rotate(new Vector3(MouseYAxis * RotationSensitivity* Time.deltaTime, -MouseXAxis * RotationSensitivity * Time.deltaTime,0));

            transform.RotateAround(target.transform.position,transform.up, MouseXAxis* RotationSensitivity);
            transform.RotateAround(target.transform.position, transform.right, -MouseYAxis * RotationSensitivity);


            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }

    bool IsPlanetPressed()
    {
        RaycastHit hitResult;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitResult, 100))
        {
            if (hitResult.transform == target)
            {
                return true;
            }
        }
        return false;
    }
}
