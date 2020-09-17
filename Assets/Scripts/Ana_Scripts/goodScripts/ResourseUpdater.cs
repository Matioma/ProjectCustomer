using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseUpdater : MonoBehaviour, IReceourceAddition<Receources>
{
    [SerializeField]
    List<GameObject> objectsToUpdate;

    public void AddReceource(Receources rec, int amount)
    {
        foreach (var item in objectsToUpdate)
        {
            var addition = GetComponent<IReceourceAddition<Receources>>();
            addition.AddReceource(rec, amount);
        }
    }

    public void ChangeConsumptionAmountSeeds(int amount)
    {
        foreach (var item in objectsToUpdate)
        {
            var addition = GetComponent<IReceourceAddition<Receources>>();
            addition.ChangeConsumptionAmountSeeds(amount);
        }
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        foreach (var item in objectsToUpdate)
        {
            var addition = GetComponent<IReceourceAddition<Receources>>();
            addition.ChangeConsumptionTimeSeeds(amount);
        }
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        foreach (var item in objectsToUpdate)
        {
            var addition = GetComponent<IReceourceAddition<Receources>>();
            addition.ChangeConsumptionAmountWater(amount);
        }
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        foreach (var item in objectsToUpdate)
        {
            var addition = GetComponent<IReceourceAddition<Receources>>();
            addition.ChangeConsumptionTimeWater(amount);
        }
    }
}
