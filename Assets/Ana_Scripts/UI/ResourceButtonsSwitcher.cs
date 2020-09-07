using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceButtonsSwitcher : MonoBehaviour
{

    [SerializeField]
    List<Button> resourcesButtons;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateButtons()
    {

    }
}
