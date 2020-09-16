using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitResources : MonoBehaviour
{
    Dictionary<Receources, int>  resources= new Dictionary<Receources, int>();

    public Dictionary<Receources, int> GetResources() {
        return resources;
    }
    private void Awake()
    {
        resources.Add(Receources.MONEY, 0);
        resources.Add(Receources.SEEDS, 0);
        resources.Add(Receources.WATER, 0);
    }

    public void AddResource(Receources resourceType, int amount) {
        resources[resourceType] += amount;
    }
}
