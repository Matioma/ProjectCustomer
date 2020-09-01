using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Material highlightMaterial;
    [SerializeField]
    string selectableTag = "Selectable";
    [SerializeField]
    Material changeMaterial;
    Transform currentSelection;
    bool selected = false;
    void Update()
    {
        Deselection();
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.tag == selectableTag)
            {

                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && selected == false)
                {
                    selectionRenderer.material = highlightMaterial;
                    currentSelection = selection;
                }

                if (Input.GetMouseButton(0))
                {
                    selected = true;
                }
            }
        }

    }

    private void Deselection()
    {
        if (selected == false)
        {
            if (currentSelection != null)
            {
                var selectionRenderer = currentSelection.GetComponent<MaterialChange>();
                selectionRenderer.ChangeMaterialBack();
                currentSelection = null;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentSelection != null)
                {
                    var selectionRenderer = currentSelection.GetComponent<MaterialChange>();
                    selectionRenderer.ChangeMaterialBack();
                    currentSelection = null;
                    selected = false;
                }
            }
        }
    }
}
