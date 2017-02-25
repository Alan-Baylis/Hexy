using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile {
    public Vector2 positionGrid;

    public GameObject associatedGOBase;
    public GameObject associatedGOOverlay;
    public GameObject associatedGOSelectionRing;
    public GameObject associatedGOTerrainTop;
    public GameObject associatedGOTerrainMid;
    public GameObject associatedGOTerrainBottom;

    public float tileValue;
    bool _selected = false;
    public bool selected
    {
        get
        {
            return _selected;
        }
        set
        {
            Debug.Log("Setting " + associatedGOSelectionRing.name + "'s Selection Ring to " + value);
            SpriteRenderer rendererSelection = null;
            foreach(SpriteRenderer _renderer in associatedGOSelectionRing.GetComponents<SpriteRenderer>())
            {
                if(_renderer.sprite.name.Contains("SelectedTile"))
                {
                    rendererSelection = _renderer;
                    break;
                }
            }
            if (rendererSelection == null)
            {
                Debug.LogWarning(associatedGOSelectionRing.name + " does not contain SpriteRenderer component");
                return;
            }
            if (value)
                rendererSelection.color = Color.white;
            else
                rendererSelection.color = Color.clear;
            _selected = value;

            if (value)
            {
                if (ReferentStatic.selected != null)
                {
                    ReferentStatic.selected.selected = false;
                }
                ReferentStatic.selected = this;
            }else
            {
                ReferentStatic.selected = null;
            }
        }
    }

    public MapTile(float tileValue, Vector2 posGrid, GameObject associatedGOBase)
    {
        AssociateInitializationVars(tileValue, posGrid, associatedGOBase);
    }
    public MapTile(float tileValue, Vector2 posGrid)
    {
        AssociateInitializationVars(tileValue, posGrid, null);
    }
    private void AssociateInitializationVars(float tileValue, Vector2 posGrid, GameObject associatedGOBase)
    {
        this.tileValue = tileValue;
        positionGrid = posGrid;
        this.associatedGOBase = associatedGOBase;
    }
}
