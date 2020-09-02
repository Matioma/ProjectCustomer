using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public event Action OnPlanetSelected;
    public event Action OnPlanetDeselected;

    bool isSelectedByPlayer =false;
    bool IsSelectedByPlayer {
        get{ return isSelectedByPlayer; }
        set{
            if (value == isSelectedByPlayer) {
                return;
            }

            isSelectedByPlayer = value;
            if (value) {
                OnPlanetSelected?.Invoke();
            }
            else
            {
                OnPlanetDeselected?.Invoke();
            }
        }
    }

    public void Deselect() {
        IsSelectedByPlayer = false;
    }
    public void Select() {
        IsSelectedByPlayer = true;
    }
}
