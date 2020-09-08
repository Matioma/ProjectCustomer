using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLeveling : MonoBehaviour
{
    [SerializeField]
    int CurrentLevel=0;

    public List<GameObject> LevelsPrefabs;

    private void Start()
    {
        RemoveOldPrefabs();
        ChangePrefab();
    }

    public void Upgrade()
    {
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
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
