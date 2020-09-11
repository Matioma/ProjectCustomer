using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    Transform target;

    [SerializeField]
    bool LookUpDown;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.transform;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!LookUpDown)
        {
            if (target != null) {
                transform.LookAt(target);
            }
        }
        else {
            Quaternion lookDirection = Quaternion.LookRotation(Vector3.down,Vector3.up);
            transform.rotation = lookDirection;
        
        }
    }
}
