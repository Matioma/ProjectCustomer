using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField]
    Sprite PauseGame;
    [SerializeField]
    Sprite ContinueGame;


    void Start()
    {
       
        Image childImage = GetChildImage();
      


        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (GlobalTimer.Instance.GameIsPaused)
            {
                if (childImage != null) {
                    childImage.sprite = ContinueGame;
                }
               
                GlobalTimer.Instance.ResumeGame();
            }
            else
            {
                if (childImage != null)
                {
                    childImage.sprite = PauseGame;
                }
                //childImage.sprite = PauseGame;
                GlobalTimer.Instance.StopGame();
            }
        });
    }

    public Image GetChildImage()
    {
        var images = GetComponentsInChildren<Image>();
        Image childImage =null;
        foreach (var image in images)
        {
            if (image.transform != this.transform)
            {
                childImage = image;
                break;
            }
        }
        return childImage;
    }

    void Update()
    {
        
    }
}
