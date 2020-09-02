using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceourceZone : MonoBehaviour
{
    [SerializeField]
    Receources typeOfReceource;

    private void Awake()
    {
        this.enabled = false;
    }

    void FixedUpdate()
    {
        Debug.Log("add rec");
        var addition = GetComponentInParent<IReceourceAddition<Receources,int>>();
        addition.AddReceource(typeOfReceource,1);
    }
}
