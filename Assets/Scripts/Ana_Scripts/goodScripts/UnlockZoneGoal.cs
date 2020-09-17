using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockZoneGoal : Goal
{
    [SerializeField]
    Receources ZoneID;
    [SerializeField]
    string description;
    [SerializeField]
    bool isCompleted = false;
    [SerializeField]
    int goalIndex;

    public void Initialize()
    {
        RequiredAmount = 1;
        CurrentAmount = 0;
        GoalIndex = goalIndex;
        Description = description;
        IsCompleted = isCompleted;
    }

    public void CompleteGoal()
    {
        RequiredAmount++;
        Evaluate();
    }

}
