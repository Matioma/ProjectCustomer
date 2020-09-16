using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMenobehaviour<T> : MonoBehaviour where T:MonoBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("Make sure that your scene has" + typeof(SingletonMenobehaviour<T>).FullName + " attached to any object");
            }
            else
            {
                return _instance;
            }
            return _instance as T;
        }
        set
        {
            if (_instance != null && _instance != value)
            {
                Destroy(value.gameObject);
                Debug.LogWarning("Tried to override" + typeof(SingletonMenobehaviour<T>).FullName + " golbat Timer value, the object is being Destroyed");
                return;
            }
            _instance = value;
        }
    }

    private void Awake()
    {
        Instance = this as T;
    }

}
