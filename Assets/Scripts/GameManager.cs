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

    //  Resources
    public int population;
    public List<int> resources;

    //  Lists
    public List<ResourceSO> allResources;  //  Lists all resources that exist in the game
    public List<BuildingSO> allBuildings;  //  Lists all buildings that exist in the game

    public List<Building> constructedBuildings; //  Buildings constructed
    public List<Building> warehouses;           //  Warehouses constructed
    public List<ResSource> resSources;          //  Res sources in the game


    //  References
    [SerializeField] UIController uiController;
    [SerializeField] BuildMode buildMode;

    void Start()
    {
        //  Compare resource list
        if (resources.Count != (int)RES.NUM_RES)
            Debug.LogWarning("Resource list count warning!");

        //  Initiate lists
        if (constructedBuildings.Count == 0)
            constructedBuildings = new();
        if (warehouses.Count == 0)
            warehouses = new();
        if (resSources.Count == 0)
            resSources = new();
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

    public void AddResource(RES resType, int amount)
    {
        //  Add the resource
        resources[(int)resType] += amount;

        //  TO DO: add capacity check
    }

    public bool TryTakeResource(RES resType, int amount)
    {
        //  If not enough - fail
        if (resources[(int)resType] < amount)
            return false;

        //  Take res and return success
        resources[(int)resType] -= amount;
        return true;
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

public enum BUILDING
{
    HOUSE,
    MILL,
    WAREHOUSE,
    MAIDAN,

    NUM_BUILDINGS
}
