using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTest : MonoBehaviour
{

    [SerializeField]
    GameObject[] planets;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < planets.Length; i++)
        //{
        //    planets[i].SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < planets.Length; i++)
            {
                planets[i].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < planets.Length; i++)
            {
                planets[i].SetActive(true);
            }
        }
    }
}
