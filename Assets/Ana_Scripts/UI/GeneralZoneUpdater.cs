using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GeneralZoneUpdater : MonoBehaviour
{
    Text text;
    Quest currentQuest;

    public void UpdateGeneralZoneText(Text newText)
    {
        text = newText;
    }

    public void UpdateGeneralZoneQuest(Quest newQuest)
    {
        currentQuest = newQuest;
    }

    public void ResetZone()
    {
        text = null;
        currentQuest = null;
    }
}
