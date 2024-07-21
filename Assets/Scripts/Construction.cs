using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public string buildName;
    public BuildingSO buildingSO;



    public List<int> constructCost;     //  Cost to build
    public int constructLabourCost;     //  Labour to build

    public List<int> resDeposited;      //  Cost to build
    public int labourDone;              //  Labour to build


    void Start()
    {
        constructCost = buildingSO.constructCost;
        constructLabourCost = buildingSO.constructLabourCost;
        buildName = buildingSO.buildName;

        //  Initiate lists
        resDeposited = new((int)RES.NUM_RES);


    }


    void Update()
    {
        
    }

    public void AddResToConstruction(RES resType, int amount)
    {
        resDeposited[(int)resType] += amount;

        CheckStatus();
    }

    public bool CheckStatus()
    {
        //  Loop thru each required resource
        for (int i = 0; i < constructCost.Count; i++)
        {
            if (resDeposited[i] < constructCost[i])
                return false;
        }

        //  Check labour
        if (labourDone < constructLabourCost)
            return false;

        //  If done - tell the Building script
        GetComponent<Building>().isConstructed = true;
        return true;
    }
}
