﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceourceZone : MonoBehaviour
{
    [SerializeField]
    Receources typeOfReceource;
    [SerializeField]
    float productivityTime=5;
    [SerializeField]
    int productionNumber = 1;
    float timer;

    private void Awake()
    {
        this.enabled = false;
    }
    private void Start()
    {
        timer = productivityTime;
    }

    void FixedUpdate()
    {
        if (timer < 0)
        {
            var addition = GetComponentInParent<IReceourceAddition<Receources, int>>();
            addition.AddReceource(typeOfReceource, productionNumber);
            timer = productivityTime;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    public void ChangeProductivityTime(int amount)
    {
        productivityTime += amount;
    }
    public void ChangeProductivityNumber(int amount)
    {
        productionNumber += amount;
    }
}