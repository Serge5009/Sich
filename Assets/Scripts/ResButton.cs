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

    }
    void CollapsePanel()
    {

    }
}
