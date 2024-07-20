using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResButton : MonoBehaviour
{

    public ResourceSO resourceSO;

    public bool isExtended;

    [SerializeField] GameObject resInfoPrefab;
    [SerializeField] GameObject extendedPanel;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] Image resImage;

    //  References
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;

        GetComponent<Button>().onClick.AddListener(OnResButtonClick);

        UpdateButtonUI();
        CollapsePanel();
    }

    void Update()
    {
        
    }

    void OnResButtonClick()
    {
        UpdateButtonUI();

        if (isExtended)
            CollapsePanel();
        else
            ExtendPanel();
    }

    void UpdateButtonUI()
    {
        resImage.sprite = resourceSO.resImage;
        valueText.text = gameManager.resources[(int)resourceSO.resID].ToString();
    }

    void ExtendPanel()
    {
        //  Make visible
        extendedPanel.SetActive(true);

        //  Populate all resources
        foreach (ResourceSO rSO in gameManager.allResources)
        {
            //  Instantiate a tab
            GameObject newTab = Instantiate(resInfoPrefab, extendedPanel.transform);
            //  Attach data
            newTab.GetComponent<ResInfo>().resourceSO = rSO;
        }


        isExtended = true;
    }
    void CollapsePanel()
    {
        //  Destroy All existing objects of the panel
        foreach (Transform panelChild in extendedPanel.transform)
        {
            Destroy(panelChild.gameObject);
        }

        //  Make invisible
        extendedPanel.SetActive(false);

        isExtended = false;
    }
}
