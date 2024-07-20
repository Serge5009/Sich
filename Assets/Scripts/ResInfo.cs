using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResInfo : MonoBehaviour
{
    public ResourceSO resourceSO;

    public int resValue;

    public bool showTotalOf;
    public bool updateEveryFrame;

    [SerializeField] Image resImage;
    [SerializeField] TextMeshProUGUI valueText;

    //  References
    GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.gameManager;

        resImage.sprite = resourceSO.resImage;
    }

    void Update()
    {
        if(updateEveryFrame)
        {
            UpdateValue();
        }
    }

    void UpdateValue()
    {
        if(showTotalOf)
        {
            valueText.text = gameManager.resources[(int)resourceSO.resID].ToString();

        }
    }
}
