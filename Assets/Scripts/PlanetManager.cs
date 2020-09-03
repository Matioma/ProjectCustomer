using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : SelectableObject
{
    public void Deselect() {
        IsSelected = false;
    }
    public void Select() {
        IsSelected = true;
    }
}
