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
    [SerializeField] GameObject buildModeUI;
    [SerializeField] GameObject BuildingPanel;
    [HideInInspector] public Building activeBuilding;

    //  Buttons
    [SerializeField] Button buildButton;

    //  Prefabs
    [SerializeField] GameObject BuildPannelButtonPrefab;

    //  References
    [SerializeField] GameManager gameManager;
    [SerializeField] BuildMode buildMode;

    void Start()
    {
        buildButton.onClick.AddListener(OnBuildButtonClick);
    }

    void Update()
    {
        if (activeBuilding)
            buildingUI.SetActive(true);
        else
            buildingUI.SetActive(false);

        buildModeUI.SetActive(buildMode.isBuildModeActive);
    }

    void OnBuildButtonClick()
    {
        //  Activate Build Panel
        BuildingPanel.SetActive(true);

        //  Destroy All existing objects of the panel
        foreach (Transform bpChild in BuildingPanel.transform)
        {
            Destroy(bpChild.gameObject);
        }

        //  Populate new ones
        foreach (BuildingSO bSO in gameManager.allBuildings)
        {
            //  Instantiate a button
            GameObject newButton = Instantiate(BuildPannelButtonPrefab, BuildingPanel.transform);
            //  Attach data
            newButton.GetComponent<BuildPanelButton>().buildingSO = bSO;
            newButton.GetComponent<BuildPanelButton>().buildMode = buildMode;
        }

    }
}
