using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelection : MonoBehaviour
{
    public event Action OnZoneSelected;
    public event Action OnZoneDeselected;

    bool isSelected;
    public bool IsSelected {
        get { return isSelected; }
        set {
            if (value == isSelected) {
                return;
            }
            isSelected = value;
            if (isSelected) { 
                OnZoneSelected?.Invoke();
            }
            else { 
                OnZoneDeselected?.Invoke();
            }
        }
    }


    [SerializeField]
    Material defaultMaterial;
    [SerializeField]
    Material selectedMaterial;


    bool MouseOver = false;

    Renderer renderer;


    void Awake() {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;

        OnZoneSelected += () => { renderer.material = selectedMaterial; };
        OnZoneDeselected += () => { renderer.material = defaultMaterial; };
    }

    void OnMouseOver() {
        if (!isSelected)
        {
            renderer.material = selectedMaterial;
        }
    }

    void OnMouseExit() {
        if (!isSelected)
        {
            renderer.material = defaultMaterial;
        }
    }
}
