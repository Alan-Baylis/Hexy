using UnityEngine;
using System.Collections;

public static class ReferentStatic {
    public enum TileTypes_Base { DeepOcean, ShallowOcean, Shore, Beach, Ground };
    //public readonly float GOPlottingScalarX = 
    public static Referent ReferentDynamic()
    {
        return GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
    }
}
