using UnityEngine;
using System.Collections;

public class TileMain : MonoBehaviour {
    public SpriteRenderer UNIT_AIR, UNIT_GROUND, TERRAIN_TOP, TERRAIN_MID, TERRAIN_BOTTOM, BACKGROUND;
    
    private bool _canHoldCity;
    public bool canHoldCity
    {
        get { return _canHoldCity; }
        set { ChangeCanHoldCity(value); }
    }
    private bool _canHoldUnitWorker;
    public bool canHoldUnitWorker
    {
        get { return _canHoldUnitWorker; }
        set { ChangeCanHoldUnitWorker(value); }
    }
    private bool _canHoldUnitGround;
    public bool canHoldUnitGround
    {
        get { return _canHoldUnitGround; }
        set { ChangeCanHoldUnitGround(value); }
    }
    private bool _canHoldUnitAerial;
    public bool canHoldUnitAerial
    {
        get { return _canHoldUnitAerial; }
        set { ChangeCanHoldUnitAerial(value); }
    }

    public CityBase currentCity;

    public void SetSpriteTerrainBottom(Sprite sprite)
    {
        TERRAIN_BOTTOM.sprite = sprite;
    }
    public void SetSpriteTerrainMid(Sprite sprite)
    {
        TERRAIN_MID.sprite = sprite;
    }
    public void SetSpriteTerrainTop(Sprite sprite)
    {
        TERRAIN_TOP.sprite = sprite;
    }
    private void ChangeCanHoldVillage(bool state)
    {

    }
    private void ChangeCanHoldCity(bool state)
    {

    }
    private void ChangeCanHoldUnitWorker(bool state)
    {

    }
    private void ChangeCanHoldUnitGround(bool state)
    {

    }
    private void ChangeCanHoldUnitAerial(bool state)
    {

    }
}