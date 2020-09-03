using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnablable<EnumType>
{
    void Enable(EnumType receource);
    void Disable(EnumType receource);
    
}
