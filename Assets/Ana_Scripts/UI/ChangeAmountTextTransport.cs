using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeAmountTextTransport : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    public void ChangeText(float value)
    {
        text.text = value.ToString();
    }
}
