using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZone : MonoBehaviour
{
    [SerializeField]
    GameObject zone;

    bool isActive = false;
    public void UnlockZone()
    {
        zone.GetComponent<ReceourceZone>().enabled = true;
        isActive = true;
    }

    public void DisableZone()
    {
        zone.GetComponent<ReceourceZone>().enabled = false;
        isActive = false;
    }

    public bool getIsActive()
    {
        return isActive;
    }
}
