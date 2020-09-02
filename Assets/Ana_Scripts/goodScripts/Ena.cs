using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            var com = GetComponent<EnableTest>();
            com.enabled = !com.enabled;
        }
    }
}
