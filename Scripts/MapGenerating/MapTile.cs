using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile {
    public Vector2 positionGrid;
    public GameObject associatedGOBase;
    public GameObject associatedGOLogic;
    public GameObject associatedGOOverlay;
    public float tileValue;

    public MapTile(float tileValue, Vector2 posGrid, GameObject associatedGOBase, GameObject associatedGOLogic, GameObject associatedGOOverlay)
    {
        AssociateInitializationVars(tileValue, posGrid, associatedGOBase, associatedGOLogic, associatedGOOverlay);
    }
    public MapTile(float tileValue, Vector2 posGrid, GameObject associatedGOBase)
    {
        AssociateInitializationVars(tileValue, posGrid, associatedGOBase, null, null);
    }
    public MapTile(float tileValue, Vector2 posGrid)
    {
        AssociateInitializationVars(tileValue, posGrid, null, null, null);
    }
    private void AssociateInitializationVars(float tileValue, Vector2 posGrid, GameObject associatedGOBase, GameObject associatedGOLogic, GameObject associatedGOOverlay)
    {
        this.tileValue = tileValue;
        positionGrid = posGrid;
        this.associatedGOBase = associatedGOBase;
        this.associatedGOLogic = associatedGOLogic;
        this.associatedGOOverlay = associatedGOOverlay;
    }
}
