using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] Image resImage;

    public ResourceSO resourceSO;


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

    }

    void UpdateButtonUI()
    {
        resImage.sprite = resourceSO.resImage;
        valueText.text = gameManager.resources[(int)resourceSO.resID].ToString();
    }

}
