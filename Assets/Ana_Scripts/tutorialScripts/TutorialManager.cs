using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject StarterPlanet;
    [SerializeField]
    Canvas MainUI;
    int tutorialScreenIndex;
    UIInformation planetInformation;
    CanvasManager mainUIManager;
    // Start is called before the first frame update
    void Start()
    {
        planetInformation = StarterPlanet.GetComponent<UIInformation>();
        mainUIManager = mainUIManager.GetComponent<CanvasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckConditions(int index)
    {
        switch (index)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
        return false;
    }
}
