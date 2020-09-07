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



    PlanetManager parentPlanetManager;

    void Awake() {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;


        parentPlanetManager = GetComponentInParent<PlanetManager>();


        OnSelected.AddListener(() => { renderer.material = selectedMaterial; });
        OnDeselected.AddListener(() => { renderer.material = defaultMaterial; });
    }

    void OnMouseOver() {
        if (parentPlanetManager != CameraController.Instance.GetSelectedPlanet()) {
            return;
        }

        if (!IsSelected )
        {
            renderer.material = selectedMaterial;
        }
    }

    void OnMouseExit() {
        if (parentPlanetManager != CameraController.Instance.GetSelectedPlanet())
        {
            return;
        }
        if (!IsSelected)
        {
            renderer.material = defaultMaterial;
        }
    }
}
