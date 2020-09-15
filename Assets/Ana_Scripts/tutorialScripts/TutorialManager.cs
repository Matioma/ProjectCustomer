using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject StarterPlanet;
    [SerializeField]
    Canvas MainUI;
    [SerializeField]
    GameObject[] tutorialScreens;
    int tutorialScreenIndex=0;
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
                if (planetInformation.GetIsZoneUnlocked(Receources.MONEY)==true)
                {

                }
                break;
            case 1:
                if (planetInformation.GetIsZoneUnlocked(Receources.WATER) == true)
                {

                }
                break;
            case 2:
                if (planetInformation.GetIsZoneUnlocked(Receources.SEEDS) == true)
                {

                }
                break;
            case 3:
                if (planetInformation.GetIsZoneUnlocked(Receources.INDUSTRIAL) == true)
                {

                }
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

    void changeScreen()
    {

    }
}
