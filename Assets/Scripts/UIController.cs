using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController uiController { get; private set; }

    private void Awake()
    {
        if (uiController != null && uiController != this)
        {
            Destroy(this);
        }
        else
        {
            uiController = this;
        }
    }

    #endregion

    [SerializeField] GameObject buildingUI;
    [HideInInspector] public Building activeBuilding;

    //  Buttons
    [SerializeField] Button buildButton;

    //  References
    [SerializeField] GameManager gameManager;

    void Start()
    {
        buildButton.onClick.AddListener(OnBuildButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBuilding)
            buildingUI.SetActive(true);
        else
            buildingUI.SetActive(false);
    }

    void OnBuildButtonClick()
    {
        Debug.Log("Build");
    }
}
