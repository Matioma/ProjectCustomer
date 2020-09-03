using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    [SerializeField]
    int water = 10;
    [SerializeField]
    int maxWater = 100;
    [SerializeField]
    int productivityIncrease = 10;
    // Start is called before the first frame update
    void Start()
    {
        var foodProd = GetComponent<FarmingZone>().Productivity;
        foodProd += productivityIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (water <= maxWater)
        {
            water++;
        }
    }
}
