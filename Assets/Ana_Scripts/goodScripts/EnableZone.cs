using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZone : MonoBehaviour
{
    [SerializeField]
    GameObject zone;
    public void UnlockZone()
    {
        zone.SetActive(true);
    }
}
