using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string buildName;
    public BuildingSO buildingSO;
    public BUILDING buildID;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void BuildingBuild()
    {
        buildName = buildingSO.buildName;
        buildID = buildingSO.buildID;
    }
}
