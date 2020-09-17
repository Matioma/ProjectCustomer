using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class IncreaseProdGoal : Goal
{
    [SerializeField]
    string description;
    [SerializeField]
    bool isCompleted = false;
    [SerializeField]
    float requiredAmount;
    [SerializeField]
    int goalIndex;

    public void Initialize()
    {
        RequiredAmount = requiredAmount;
        GoalIndex = goalIndex;
        Description = description;
        IsCompleted = isCompleted;
        CurrentAmount = 0;
    }

    public void UpdateCurrentAmount(float amount)
    {
        CurrentAmount = amount;
        Evaluate();
    }

}
