using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildPanelButton : MonoBehaviour
{
    public BuildingSO buildingSO;

    [SerializeField] TextMeshProUGUI nameField;

    [HideInInspector] public BuildMode buildMode;

    void Start()
    {
        nameField.text = buildingSO.buildName;
        GetComponent<Button>().onClick.AddListener(OnBButtonClick);
    }

    void Update()
    {
        
    }

    void OnBButtonClick()
    {
        buildMode.EnterBuildMode(buildingSO);
    }
}
