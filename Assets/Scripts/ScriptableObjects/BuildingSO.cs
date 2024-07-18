using UnityEngine;

[CreateAssetMenu(fileName = "New building", menuName = "Economy/Buildings")]
public class BuildingSO : ScriptableObject
{
    public BUILDING buildID;
    public string buildName;
    public Sprite buildImage;

    public GameObject buildModel;
}
