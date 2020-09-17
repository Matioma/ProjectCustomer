using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal
{
    [HideInInspector]
    public string Description;
    [HideInInspector]
    public bool IsCompleted=false;
    [HideInInspector]
    public float CurrentAmount;
    [HideInInspector]
    public float RequiredAmount;
    [HideInInspector]
    public int GoalIndex;

    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        IsCompleted = true;
    }
}
