using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager gameManager { get; private set; }

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    #endregion


    public GameObject focusedObject;


    //  References
    [SerializeField] UIController uiController;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MouseClickCheck();
        }
    }

    void MouseClickCheck()
    {
        focusedObject = null;
        uiController.activeBuilding = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Clickable hitClick = hit.transform.GetComponent<Clickable>();
            if (hitClick)
                hitClick.OnClickableClick();
        }

    }

}

public enum C_TYPE
{
    BUILDING,

    NUM_C_TYPES
}

public enum RES
{
    WOOD,
    STRAW,
    STONE,
    METAL,
    FOOD,



    NUM_RES
}
