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
        var scr = GetComponent<PlanetReceources>();
       // Debug.Log("planetB");
       // Debug.Log("seeds="+scr.GetReceouceNumber(Receources.SEEDS));
        ///Debug.Log("water="+scr.GetReceouceNumber(Receources.WATER));
       // Debug.Log("money="+scr.GetReceouceNumber(Receources.MONEY));
    }
}
