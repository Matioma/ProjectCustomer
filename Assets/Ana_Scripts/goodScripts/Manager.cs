using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    Planet[] planets;
    [SerializeField]
    GameObject tutorial;
    

    private void Start()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].gameObject.SetActive(false);
        }
        tutorial.SetActive(false);
    }
    public void PlayGame()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].gameObject.SetActive(true);
        }
        tutorial.SetActive(true);
        CameraController.Instance.SelectInitialPlanet();
    }

    public void ReploadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
