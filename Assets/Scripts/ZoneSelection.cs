using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelection : SelectableObject
{
    Material defaultMaterial;
    [SerializeField]
    Material selectedMaterial;

    Renderer renderer;

    Planet parentPlanetManager;

    public float scaleRegion = 0.1f;

    Vector3 initialScale;
    Vector3 initialPosition;
    
    [SerializeField]
    float ZoneDisplacement = 15f;

    void Awake() {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;

        initialScale = transform.localScale;
        initialPosition = transform.localPosition;
        
        parentPlanetManager = GetComponentInParent<Planet>();

        OnSelected.AddListener(() =>
        {
            renderer.material = selectedMaterial;
            ScaleRegion(scaleRegion);
            ContinentDirection direction = GetComponent<ContinentDirection>();
            if (direction != null)
            {
                transform.localPosition += direction.getDirection().normalized * (-ZoneDisplacement);
            }
            else {
                Debug.Log("Zone does not have Continent Direction Attached");
            }
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
