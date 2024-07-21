using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string buildName;
    public BuildingSO buildingSO;
    public BUILDING buildID;

    public List<int> resourcesInside;  //  All resources inside the building (construction or production)

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
        buildName = buildingSO.buildName;
        buildID = buildingSO.buildID;
        constructCost = buildingSO.constructCost;
        constructLabourCost = buildingSO.constructLabourCost;
    }
}
