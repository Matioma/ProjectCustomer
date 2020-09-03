using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum PosibleActions
{
    Buy,
    AnotherAction,
    ToDoAction
}
public class Zone : MonoBehaviour
{
    [SerializeField]
    List<PosibleActions> ZoneActionsList;

    public string Name;


    void Awake() {
    }
}
