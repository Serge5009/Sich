using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public bool isBuildModeActive = false;


    //  References
    public GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitBuildMode();
    }

    public void EnterBuildMode()
    {
        isBuildModeActive = true;
    }

    public void ExitBuildMode()
    {
        isBuildModeActive = false;
    }
}
