using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject tutorial;
    [SerializeField]
    GameObject StarterPlanet;
    [SerializeField]
    Canvas MainUI;
    [SerializeField]
    GameObject[] tutorialScreens;
    [SerializeField]
    GameObject playerChoice;
    [SerializeField]
    Button skipButton;
    [SerializeField]
    Button nextButton;
    [SerializeField]
    int delay;
    int tutorialScreenIndex = -1;
    UIInformation planetInformation;
    CanvasManager mainUIManager;

    void Start()
    {
        planetInformation = StarterPlanet.GetComponent<UIInformation>();
        mainUIManager = MainUI.GetComponent<CanvasManager>();
    }

    void Update()
    {
        changeScreen();
    }

    bool CheckConditions(int index)
    {
        switch (index)
        {
            case 0:
                if (planetInformation.GetIsZoneUnlocked(Receources.MONEY) == true)
                {
                    return true;
                }
                break;
            case 1:
                if (planetInformation.GetIsZoneUnlocked(Receources.WATER) == true)
                {
                    return true;
                }
                break;
            case 2:
                if (planetInformation.GetIsZoneUnlocked(Receources.SEEDS) == true)
                {
                    return true;
                }
                break;
            case 3:
                if (planetInformation.GetIsZoneUnlocked(Receources.INDUSTRIAL) == true)
                {
                    return true;
                }
                break;
            case 4:
                if (planetInformation.GetIsOneUpgradeBought() == true)
                {
                    return true;
                }
                break;
            case 5:
                if (mainUIManager.GetCurrentCanvas().type == CanvasType.TransportZone)
                {
                    return true;
                }
                break;
            case 6:
                if (mainUIManager.GetCurrentCanvas().type == CanvasType.NoZone)
                {
                    return true;
                }
                break;

        }
        return false;
    }

    void getNextScreen()
    {
        tutorialScreens[tutorialScreenIndex].SetActive(true);
        nextButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
    }

    void changeScreen()
    {
        if (CheckConditions(tutorialScreenIndex) == true)
        {
            tutorialScreens[tutorialScreenIndex].SetActive(false);
            nextButton.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(false);
            if (tutorialScreenIndex == tutorialScreens.Length - 1)
            {
                CompleteTutorial();
            }
            else
            {
                for (int i = tutorialScreenIndex + 1; i < tutorialScreens.Length; i++)
                {
                    if (CheckConditions(i) == false)
                    {
                        tutorialScreenIndex = i;
                        break;
                    }
                }
                Invoke("getNextScreen", delay);
            }
        }
    }

    public void CompleteTutorial()
    {
        GlobalTimer.Instance.StartTimer();

        tutorial.SetActive(false);
    }

    public void GoToNextScreen()
    {
        tutorialScreens[tutorialScreenIndex].SetActive(false);
        tutorialScreens[tutorialScreenIndex+1].SetActive(true);
        tutorialScreenIndex++;
    }

    public void StartTutorial()
    {
        tutorialScreenIndex++;
        tutorialScreens[tutorialScreenIndex].SetActive(true);
        playerChoice.SetActive(false);
        skipButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }
}
