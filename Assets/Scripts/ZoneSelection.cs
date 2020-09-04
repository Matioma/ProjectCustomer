using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelection : SelectableObject
{
    [SerializeField]
    Material defaultMaterial;
    [SerializeField]
    Material selectedMaterial;



    bool MouseOver = false;

    Renderer renderer;

    void Awake() {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;


        OnSelected.AddListener(() => { renderer.material = selectedMaterial; });
        OnDeselected.AddListener(() => { renderer.material = defaultMaterial; });
    }

    void OnMouseOver() {
        if (!IsSelected)
        {
            renderer.material = selectedMaterial;
        }
    }

    void OnMouseExit() {
        if (!IsSelected)
        {
            renderer.material = defaultMaterial;
        }
    }
}
