using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentDirection : MonoBehaviour
{
    [SerializeField]
    Vector3 VectorStart;

    [SerializeField]
    Vector3 vectorDirection;
    public Vector3 getWorldDirection() {
        return transform.rotation*vectorDirection.normalized;
    }
    public Vector3 getDirection() {
        return vectorDirection.normalized;
    }


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

        Gizmos.DrawRay(transform.position + VectorStart, transform.rotation*vectorDirection.normalized * VectorLength);
        //Gizmos.DrawRay(ray);
    }

}
