using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainTestHandler : MonoBehaviour {

    public Vector2 offset;
    public Vector2 count;
    public GameObject hexagonPrefab;
    public GameObject hexaGridParent;

    //private List<GameObject> createdObjects = new List<GameObject>();
    public GameObject[,] map;

    public float frequency = 0.7f, scaling = 0.15f;
    [Range(0f,5f)]
    public float multiplicator = 1f;
    [Range(-1f, 1f)]
    public float addition = 0f;
    public uint resolution = 256;
    public Gradient coloring = MapTypes.TemplateLakes.coloring;
    private float lastFrequency = 0, lastScaling = 0, lastMultiplicator = 0, lastAddition = 0;
    private uint lastResolution = 0;
    private Gradient lastColoring = null;

    public GameObject plane;
    public bool debugTexture = false;
    
    void Start()
    {
        if (!debugTexture)
            Destroy(plane);
        GameObject[,] _map = new GameObject[(int)count.x, (int)count.y];
        for (int y = 0; y < count.y; y++)
        {
            for (int x = 0; x < count.x; x++)
            {
                float newY;
                if (IsOdd(x))
                    newY = y * offset.y + offset.y / 2f;
                else
                    newY = y * offset.y;
                Vector2 newPos = new Vector2(x * offset.x, newY);
                GameObject created = (GameObject)Instantiate(hexagonPrefab, newPos, Quaternion.identity);
                /*SpriteRenderer sr = created.GetComponent<SpriteRenderer>();
                sr.color = Random.ColorHSV();*/
                created.transform.SetParent(hexaGridParent.transform, true);
                //createdObjects.Add(created);
                _map[x, y] = created;
            }
        }
        float xPos = (count.x * offset.x) / 2f;
        float yPos = (count.y * offset.y) / 2f;
        Camera.main.transform.position = new Vector3(xPos, yPos, -10);

        map = _map;

        Debug.Log("Generating terrain");
        MapGeneratorInstance original = MapTypes.TemplateLakes;
        MapGeneratorInstance forged = new MapGeneratorInstance(original.resolution, original.octaves, original.frequency, original.lacunarity, original.persistence, original.scaling, original.seed, original.coloring, original.multiplicator, original.addition);
        //PerlinNoiseParser.GenerateTest(MapTypes.TemplateLakes, _map);
        PerlinNoiseParser.GenerateTest(forged, _map);
        Debug.Log(" ..took " + Time.deltaTime * 1000 + "ms");
    }
    void Update()
    {
        if (debugTexture&&(lastColoring == null || frequency != lastFrequency || scaling != lastScaling || coloring.colorKeys != lastColoring.colorKeys || lastMultiplicator != multiplicator || lastAddition != addition || lastResolution != resolution))
        {
            lastFrequency = frequency;
            lastScaling = scaling;
            lastColoring = coloring;
            lastMultiplicator = multiplicator;
            lastAddition = addition;
            lastResolution = resolution;
            MapGeneratorInstance original = MapTypes.TemplateLakes;
            MapGeneratorInstance forged = new MapGeneratorInstance((int)resolution, original.octaves, frequency, original.lacunarity, original.persistence, scaling, original.seed, coloring, multiplicator, addition);
            Texture2D texture = new Texture2D(forged.resolution,forged.resolution,TextureFormat.RGB24,true);
            texture.filterMode = FilterMode.Point;
            texture = PerlinNoiseParser.GenerateTest(forged, texture);
            texture.Apply();
            plane.GetComponent<MeshRenderer>().material.mainTexture = texture;
        }
    }
    bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}
