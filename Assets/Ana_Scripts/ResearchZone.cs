using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchZone : MonoBehaviour
{
    [SerializeField]
    int RocketMoney = 10;
    PlanetState planetstate;
    // Start is called before the first frame update
    void Start()
    {
        planetstate = GetComponent<PlanetState>();
    }

    void buyObject()
    {
        planetstate.Money -= RocketMoney;
    }
}
