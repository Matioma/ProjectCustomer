using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleAndDescriptionUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI description;

    public void Initialize(string newTitle, string newDescription)
    {
        title.text = newTitle;
        description.text = newDescription;
    }
}
