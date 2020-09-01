using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    [SerializeField]
    Material defaultMaterial;

    public void ChangeMaterialBack()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material = defaultMaterial;
    }
}
