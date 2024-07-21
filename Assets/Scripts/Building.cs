using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string buildName;
    public BuildingSO buildingSO;
    public BUILDING buildID;

    public List<int> resourcesInside;  //  All resources inside the building (construction or production)
    public bool accessToStorage;

    [SerializeField] List<int> constructCost;    //  Cost to build
    [SerializeField] int constructLabourCost;    //  Labour to build

    //  References
    public GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.gameManager;

        resourcesInside = new((int)RES.NUM_RES);
    }


    void Update()
    {
        
    }

    public void BuildingBuild()
    {
        gameManager = GameManager.gameManager;

        //  Fetch data
        buildName = buildingSO.buildName;
        buildID = buildingSO.buildID;
        constructCost = buildingSO.constructCost;
        constructLabourCost = buildingSO.constructLabourCost;
        accessToStorage = buildingSO.accessToStorage;

        //  Add to lists
        gameManager.constructedBuildings.Add(this);
        if(accessToStorage)
            gameManager.warehouses.Add(this);


    }
}
