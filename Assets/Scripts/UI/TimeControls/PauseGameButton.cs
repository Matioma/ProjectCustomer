using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameButton : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (GlobalTimer.Instance.GameIsPaused)
            {
                GlobalTimer.Instance.ResumeGame();
            }
            else
            {
                GlobalTimer.Instance.StopGame();
            }
        });
    }

    void Update()
    {
        
    }
}
