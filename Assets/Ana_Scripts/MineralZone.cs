using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralZone : MonoBehaviour
{
    int money;
    [SerializeField]
    int fertiliser = 0;

    PlanetState planetstate;
    // Start is called before the first frame update
    void Start()
    {
        planetstate = GetComponent<PlanetState>();
    }

    // Update is called once per frame
    void Update()
    {
        planetstate.Money++;
        fertiliser++;
    }
}
