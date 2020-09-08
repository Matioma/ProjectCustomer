using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneUpgrading : MonoBehaviour
{
    [SerializeField]
    int CurrentLevel=0;

    public List<GameObject> LevelsPrefabs;

    private void Start()
    {
        if (LevelsPrefabs.Count == 0)
        {
            return;
        }

        RemoveOldPrefabs();
        ChangePrefab();
    }

    public void Upgrade()
    {
        if (LevelsPrefabs.Count == 0) {
            return;
        }
        if (CurrentLevel < LevelsPrefabs.Count)
        {
            CurrentLevel++;
            RemoveOldPrefabs();
            ChangePrefab();
        }
        else{
            Debug.Log("Tried to Upgrade region out of it max capacity");
        }
    }

    void ChangePrefab() {
        LevelsPrefabs[CurrentLevel].SetActive(true);
    }

    void RemoveOldPrefabs() {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
