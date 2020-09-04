using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentDirection : MonoBehaviour
{
    [SerializeField]
    Vector3 VectorStart;

    [SerializeField]
    Vector3 VectorDirection;
    [SerializeField]
    float VectorLength;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + VectorStart, 3.0f);

        //Ray ray = new Ray(VectorStart,VectorDirection*VectorLength);
        Gizmos.DrawRay(transform.position + VectorStart, VectorDirection * VectorLength);
        //Gizmos.DrawRay(ray);
    }

}
