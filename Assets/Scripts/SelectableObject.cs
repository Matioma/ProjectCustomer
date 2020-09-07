using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    //public event Action OnSelected;
    //public event Action OnDeselected;


    public UnityEngine.Events.UnityEvent OnSelected;
    public UnityEngine.Events.UnityEvent OnDeselected;

    bool isSelected;
    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            if (value == isSelected)
            {
                return;
            }
            isSelected = value;
            if (isSelected)
            {
                OnSelected?.Invoke();
            }
            else
            {
                OnDeselected?.Invoke();
            }
        }
    }

    public void Deselect()
    {
        IsSelected = false;
    }
    public void Select()
    {
        IsSelected = true;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
