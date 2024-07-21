using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "New building", menuName = "Economy/Buildings")]
public class BuildingSO : ScriptableObject
{
    public BUILDING buildID;
    public string buildName;
    public Sprite buildImage;

    public GameObject buildModel;

    public bool accessToStorage;

    public List<int> constructCost;    //  Cost to build
    public int constructLabourCost;    //  Labour to build

}
