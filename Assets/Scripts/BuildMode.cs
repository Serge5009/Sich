using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public bool isBuildModeActive = false;

    public BuildingSO buildingToBuild;
    public Vector3 cursorPositionOnTerrain;

    //  References
    public GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        //  Close the menu on Escape
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitBuildMode();

        //  Update location of cursor on the terrain
        if (isBuildModeActive)
            UpdateCursorPosition();
    }

    public void EnterBuildMode(BuildingSO bToBuild)
    {
        buildingToBuild = bToBuild;
        isBuildModeActive = true;
    }

    public void ExitBuildMode()
    {
        isBuildModeActive = false;
    }

    void UpdateCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int terrainLayerMask = 1 << 6; // Bit shift to create mask
        if (Physics.Raycast(ray, out hit, 1000, terrainLayerMask))
        {
            if (hit.transform)
            {
                cursorPositionOnTerrain = hit.point;
            }
        }

        Debug.Log(cursorPositionOnTerrain);
    }
}
