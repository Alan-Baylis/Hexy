using UnityEngine;
using System.Collections;

public class PerlinNoiseParser {
    
    public static void GenerateTest(MapGeneratorInstance type, GameObject[,] mapGrid)
    {
        if (mapGrid == null)
            throw new System.Exception("Map Grid is not initialized");
        float[,] pointsG = new float[type.resolution, type.resolution];
        for(int x = 0; x < type.resolution; x++)
        {
            for(int y = 0; y < type.resolution; y++)
            {
                
                float newSeed = type.seed * 1000;
                Vector2 vector = new Vector2((x + newSeed) * type.scaling, (y + newSeed) * type.scaling);
                float noise = PerlinNoiseGenerator.Sum(vector, type.frequency, type.octaves, type.lacunarity, type.persistence, type.multiplicator, type.addition);
                pointsG[x, y] = noise;
            }
        }

        for(int a = 0; a < mapGrid.GetLength(0); a++)
        {
            for(int b = 0; b < mapGrid.GetLength(1); b++)
            {
                Color color = type.coloring.Evaluate(pointsG[a, b]);
                Debug.Log("Map dimensions: " + mapGrid.GetLength(0) + "x" + mapGrid.GetLength(1));
                Debug.Log("Trying to access field " + a + "x" + b);
                GameObject modified = mapGrid[a, b];
                modified.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
    public static Texture2D GenerateTest(MapGeneratorInstance type, Texture2D texture)
    {
        if (texture == null)
            throw new System.Exception("Texture2D is not initialized");
        for (int x = 0; x < type.resolution; x++)
        {
            for (int y = 0; y < type.resolution; y++)
            {

                float newSeed = type.seed * 1000;
                Vector2 vector = new Vector2((x + newSeed) * type.scaling, (y + newSeed) * type.scaling);
                float noise = PerlinNoiseGenerator.Sum(vector, type.frequency, type.octaves, type.lacunarity, type.persistence, type.multiplicator, type.addition);
                texture.SetPixel(x, y, type.coloring.Evaluate(noise));
            }
        }
        return texture;
    }
}
