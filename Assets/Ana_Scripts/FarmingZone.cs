using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingZone : MonoBehaviour
{
    [SerializeField]
    int seeds=100;
    [SerializeField]
    int productivity=-1;
    PlanetState planetState;

    private void Start()
    {
        planetState = GetComponent<PlanetState>();

    }
    public int Productivity
    {
        get
        {
            return productivity;
        }
        set
        {
            productivity += value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        seeds += productivity;
    }
}
