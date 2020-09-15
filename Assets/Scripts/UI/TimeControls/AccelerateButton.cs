using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerateButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GlobalTimer.Instance.AccelerateGame();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
