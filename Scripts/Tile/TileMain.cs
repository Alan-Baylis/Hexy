using UnityEngine;
using System.Collections;

public class TileMain : MonoBehaviour {
    public SpriteRenderer UNIT_AIR, UNIT_GROUND, TERRAIN_TOP, TERRAIN_MID, TERRAIN_BOTTOM, BACKGROUND;

    public bool canHoldVillage;
    public bool canHoldCity;
    public bool canHoldUnitWorker;
    public bool canHoldUnitGround;
    public bool canHoldUnitAerial;

    private Aerial _currentAerial;
    public Aerial currentAerial => _currentAerial;
    private Worker _currentWorker;
    public Worker currentWorker
    {
        get
        {
            return _currentWorker;
        }
    }
    private Ground
}