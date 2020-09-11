using UnityEngine;

public class PlanetIndicator : MonoBehaviour
{
    CameraController player;
    Camera camera;


    [SerializeField]
    GameObject exclamationMark;






    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        player = CameraController.Instance;


        if (player != null) {
            player.OnZoomToWorldView += ShowUI;
            player.OnZoomToPlanet+= HideUI;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);
    }

    void ShowUI() {
        gameObject.SetActive(true);
    }

    void HideUI() {
        gameObject.SetActive(false);
        
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.OnZoomToWorldView -= ShowUI;
            player.OnZoomToPlanet -= HideUI;
        }
    }

    void ShowExclamationMark() {
        exclamationMark.SetActive(true);
    }

    void HideExclamationMark()
    {
        exclamationMark.SetActive(false);
    }
}
