using UnityEngine;
using System.Collections;

public static class MapGenerator{
    public static GameObject[,] CreateBlankGrid(Vector2 size, int layer)
    {
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        Debug.Log("#0");
        int width = (int)size.x;
        int height = (int)size.y;
        GameObject[,] created = new GameObject[width, height];
        Debug.Log("#1");
        for (int x = 0; x < width; x++)
        {
            Debug.Log("#2");
            for (int y = 0; y < height; y++)
            {
                Debug.Log("#3");
                float newY;
                if (x % 2 != 0)
                    newY = y * 1.36f + 1.36f / 2f;
                else
                    newY = y * 1.36f;
                Vector2 pos = new Vector2(x * 1.18f, newY);
                Debug.Log("#4");
                GameObject instantiated = (GameObject)GameObject.Instantiate(referent.PFHexagonTileBlank, pos, Quaternion.identity);
                Debug.Log("#5");
                instantiated.transform.SetParent(referent.GOMapParent.transform, true);
                created[x, y] = instantiated;
            }
        }
        return created;
    }
    public static GameObject[,] MakeTerrainBase(GameObject[,] map, GeneratorType type)
    {
        if (map == null)
            throw new System.Exception("Base Grid does not exist", new System.NullReferenceException());
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        float[,] pointsG = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float newSeed = type.seed * 2016;
                Vector2 vector = new Vector2((x + newSeed) * type.scaling, (y + newSeed) * type.scaling);
                float value = PerlinNoise.Sum(vector, type.frequency, type.octaves, type.lacunarity, type.persistence, type.multiplicator, type.addition);
                pointsG[x, y] = value;
                SetBaseTileType(map[x, y], value, type);
            }
        }
        return map;
    }
    public static GameObject SetBaseTileType(GameObject tile, float value, GeneratorType type)
    {
        Color color = type.coloring.Evaluate(value);
        tile.GetComponent<SpriteRenderer>().color = color; //TODO Change to types instead of colors
        return tile;
    }
}
