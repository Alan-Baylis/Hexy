using UnityEngine;
using System.Collections;

public static class MapGenerator{
    public static GameObject[,] CreateBlankGrid(Vector2 size, int layer)
    {
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        int width = (int)size.x;
        int height = (int)size.y;
        GameObject[,] created = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float newY;
                if (x % 2 != 0)
                    newY = y * 1.36f + 1.36f / 2f;
                else
                    newY = y * 1.36f;
                Vector2 pos = new Vector2(x * 1.18f, newY);
                GameObject instantiated = (GameObject)Object.Instantiate(referent.PFHexagonTileBlank, pos, Quaternion.identity);
                instantiated.transform.SetParent(referent.GOMapParent.transform, true);
                created[x, y] = instantiated;
            }
        }
        return created;
    }
    public static GameObject[,] MakeTerrainBase(GameObject[,] map, GeneratorType type, float seed)
    {
        if (map == null)
            throw new System.Exception("Base Grid does not exist", new System.NullReferenceException());
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        float[,] pointsG = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float newSeed = seed * 2016;
                Vector2 vector = new Vector2((x + newSeed) * type.scaling, (y + newSeed) * type.scaling);
                float value = PerlinNoise.Sum(vector, type.frequency, type.octaves, type.lacunarity, type.persistence, type.multiplicator, type.addition);
                pointsG[x, y] = value;
                SetBaseTileType(map[x, y], value, type, referent);
            }
        }
        return map;
    }
    public static GameObject SetBaseTileType(GameObject tile, float value, GeneratorType type, Referent referent)
    {
        Color color = type.coloring.Evaluate(value);
        tile.GetComponent<SpriteRenderer>().sprite = GetSpriteForValue(value, referent);
        return tile;
    }
    private static Sprite GetSpriteForValue(float value, Referent referent)
    {
        if (value < 0.02f)
            return referent.TexturesBase[0];
        if (value < 0.15f)
            return referent.TexturesBase[1];
        if (value < 0.4f)
            return referent.TexturesBase[2];
        if (value < 0.58f)
            return referent.TexturesBase[3];
        return referent.TexturesBase[4];
    }
}
