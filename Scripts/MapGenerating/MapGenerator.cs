using UnityEngine;
using System.Collections;

public static class MapGenerator{
    
    public static float[,] GenerateTerrainValues(int sizeX, int sizeY, GeneratorType genType, float seed)
    {
        if (sizeX <= 0 || sizeY <= 0)
            throw new System.Exception("Invalid dimensions");
        seed *= System.DateTime.Now.Millisecond * System.DateTime.Now.Year;
        float[,] toReturn = new float[sizeX, sizeY];
        for(int x = 0; x < sizeX; x++)
            for(int y = 0; y < sizeY; y++)
            {
                Vector2 vector = new Vector2((x + seed) * genType.scaling, (y + seed) * genType.scaling);
                float localValue = PerlinNoise.Sum(vector, genType);
                toReturn[x, y] = localValue;
            }
        return toReturn;
    }
    #region obsolete
    /*public static Map CreateBlankGrid(Vector2 size, int layer)
    {
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        int width = (int)size.x;
        int height = (int)size.y;
        Map map = new Map(width, height);
        for(int i = 0; i < width; i++)
            for(int j = 0; j < height; j++)
            {
                float newY;
                if (i % 2 != 0)
                    newY = j * 1.36f + 1.36f / 2f;
                else
                    newY = j * 1.36f;
                Vector2 pos = new Vector2(i * 1.18f, newY);
                GameObject instantiated = (GameObject)Object.Instantiate(referent.PFHexagonTileBlank, pos, Quaternion.identity);
                instantiated.transform.SetParent(referent.GOMapParent.transform, true);
                pos = instantiated.transform.position;
                map.AddTile(instantiated, new Vector2(i, j), pos);
            }
        return map;
    }
    public static Map MakeTerrainBase(Map map, GeneratorType type, float seed)
    {
        if (map == null)
            throw new System.Exception("Map does not exist", new System.NullReferenceException());
        Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        seed *= 2016;
        for(int i = 0; i < map.Width; i++)
            for(int j = 0; j < map.Height; j++)
            {
                Vector2 vector = new Vector2((i + seed) * type.scaling, (j + seed) * type.scaling);
                float noise = PerlinNoise.Sum(vector, type.frequency, type.octaves, type.lacunarity, type.persistence, type.multiplicator, type.addition);
                GameObject modified = SetBaseTileType(map.GetTileAtGrid(new Vector2(i, j)), noise, type, referent);
                map.ChangeTile(modified, new Vector2(i, j), modified.transform.position);
            }
        return map;
    }
    public static GameObject SetBaseTileType(GameObject tile, float value, GeneratorType type, Referent referent)
    {
        tile.GetComponent<TileMain>().TERRAIN_BOTTOM.sprite = GetSpriteForValue(value, referent);
        return tile;
    }
    public static GameObject SetBaseTileType(GameObject tile, ReferentStatic.TileTypes_Base type, Referent referent)
    {
        tile.GetComponent<SpriteRenderer>().sprite = GetSpriteForType(type, referent);
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
    private static Sprite GetSpriteForType(ReferentStatic.TileTypes_Base type, Referent referent)
    {
        switch (type)
        {
            case ReferentStatic.TileTypes_Base.DeepOcean:
                return referent.TexturesBase[0];
            case ReferentStatic.TileTypes_Base.ShallowOcean:
                return referent.TexturesBase[1];
            case ReferentStatic.TileTypes_Base.Shore:
                return referent.TexturesBase[2];
            case ReferentStatic.TileTypes_Base.Beach:
                return referent.TexturesBase[3];
            case ReferentStatic.TileTypes_Base.Ground:
                return referent.TexturesBase[4];
            default:
                return null;
        }
    }*/
    #endregion
}
