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

    public float scaleRegion = 0.1f;

    public Vector3 initialScale;
    public Vector3 initialPosition;
    public float moveBack = 15f;

    void Awake() {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;

        initialScale = transform.localScale;
        initialPosition = transform.localPosition;
        


        parentPlanetManager = GetComponentInParent<PlanetManager>();


        OnSelected.AddListener(() =>
        {
            renderer.material = selectedMaterial;
            ScaleRegion(scaleRegion);
            transform.localPosition += GetComponent<ContinentDirection>().getDirection().normalized* (-moveBack);
        });
        OnDeselected.AddListener(() =>
        {
            renderer.material = defaultMaterial;
            transform.localPosition = initialPosition;
            transform.localScale = initialScale;
        });
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
    void ScaleRegion(float value) {
        transform.localScale +=new Vector3(value,value,value);
    }
}
