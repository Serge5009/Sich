using UnityEngine;

[CreateAssetMenu(fileName = "New resource", menuName = "Economy/Resources")]
public class ResourceSO : ScriptableObject
{
    public RES resID;
    public string resName;
    public Sprite resImage;
}
