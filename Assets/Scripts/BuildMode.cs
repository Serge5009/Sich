using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public bool isBuildModeActive = false;

    public BuildingSO buildingToBuild;
    public Vector3 cursorPositionOnTerrain;
    GameObject buildingProjection;

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

        //  Project building if possible
        if (isBuildModeActive && cursorPositionOnTerrain != Vector3.zero)
            ProjectBuildingModel();

        //  Try to build on mouse click
        if (Input.GetMouseButtonDown(0))
            TryToBuild();
    }

    public void EnterBuildMode(BuildingSO bToBuild)
    {
        buildingToBuild = bToBuild;
        isBuildModeActive = true;

        //  Reset mouse position
        cursorPositionOnTerrain = Vector3.zero;
    }

    public void ExitBuildMode()
    {
        isBuildModeActive = false;
        //  Destroy old building projection
        Destroy(buildingProjection);
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

        //Debug.Log(cursorPositionOnTerrain);
    }

    void ProjectBuildingModel()
    {
        //  Create model if doesn't exist
        if(!buildingProjection)
        {
            buildingProjection = Instantiate(buildingToBuild.buildModel, cursorPositionOnTerrain, Quaternion.identity);
        }

        buildingProjection.transform.position = cursorPositionOnTerrain;
    }

    void TryToBuild()
    {
        Build();

        
    }

    void Build()
    {
        //  Creating the building
        GameObject newBuilding = Instantiate(buildingToBuild.buildModel, cursorPositionOnTerrain, Quaternion.identity);     //  Instantiate the model
        Building newBuildingScript = newBuilding.AddComponent<Building>();                                                  //  Add Building script
        newBuildingScript.buildingSO = buildingToBuild;                                                                     //  Attach data
        newBuildingScript.BuildingBuild();                                                                                  //  Trigger the build function

        //  Exiting build mode
        ExitBuildMode();
    }
}
