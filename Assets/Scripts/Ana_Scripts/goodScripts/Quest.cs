using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    [SerializeField]
    List<UnlockZoneGoal> unlockZoneGoals;
    [SerializeField]
    List<IncreaseProdGoal> increaseProdGoals;
    List<Goal> goals;
    bool completed;
    int currentGoal = 0;

    private void Start()
    {
        foreach (UnlockZoneGoal item in unlockZoneGoals)
        {
            goals[item.GoalIndex] = item;
        }
        foreach (IncreaseProdGoal item in increaseProdGoals)
        {
            goals[item.GoalIndex] = item;
        }
    }
    public List<Goal> getGoalList()
    {
        return goals;
    }
    public void CheckGoals()
    {
        if(goals.All(g => g.IsCompleted))
        {
            Complete();
        }
    }

    void Complete()
    {
        completed = true;
    }
}
