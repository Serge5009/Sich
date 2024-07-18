using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildPanelButton : MonoBehaviour
{
    public BuildingSO buildingSO;

    [SerializeField] TextMeshProUGUI nameField;

    void Start()
    {
        nameField.text = buildingSO.buildName;
    }

    void Update()
    {
        
    }
}
