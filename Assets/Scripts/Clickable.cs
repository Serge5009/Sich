using UnityEngine;

public class Clickable : MonoBehaviour
{
    public C_TYPE cType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickableClick()
    {
        Debug.Log(name);
        GameManager.gameManager.focusedObject = gameObject;
    }
}
