using UnityEngine;
using System.Collections;

public class Referent : MonoBehaviour {
    public GameObject GOMapParent;
    public GameObject PFHexagonTileBlank;
    public GameObject[,] ArrayMap;
    public Sprite[] TexturesBase = new Sprite[5];
    public enum TileTypes_Base { DeepOcean, ShallowOcean, Shore, Beach, Ground};
}
