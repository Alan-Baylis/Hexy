using UnityEngine;
using System.Collections;

public static class ReferentStatic {
    public enum TileTypes_Base { DeepOcean, ShallowOcean, Shore, Beach, Ground };
    public enum ObjectTypes { Unit, City, Effect, None}
    public static readonly float GOPlottingScalarX = 1.18f;
    public static readonly float GOPlottingScalarY = 1.36f;
    public static MapTile selected = null;
    public static Referent ReferentDynamic()
    {
        return GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
    }
}
