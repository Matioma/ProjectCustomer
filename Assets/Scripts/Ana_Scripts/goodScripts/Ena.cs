using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ena : MonoBehaviour
{
    [System.Serializable]
    public class Rec
    {
        public Receources type;
        public int amount;
    }
    [SerializeField]
    Rec[] recs;
    [SerializeField]
    Goal [] goal;
    UnlockZoneGoal[] ugoal;
    IncreaseProdGoal[] igoal;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var scr = GetComponent<PlanetReceources>();

    }
}
