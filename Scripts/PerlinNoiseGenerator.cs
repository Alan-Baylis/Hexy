using UnityEngine;
using System.Collections;

public class PerlinNoiseGenerator {
    
    /*[Range(2,512)]
    public int resolution = 256;

    public float frequency = 1f;
    [Range(1, 8)]
    public int octaves = 1;
    [Range(1f, 4f)]
    public float lacunarity = 2f;
    [Range(0f, 1f)]
    public float persistence = 0.5f;
    [Range(0.005f, 0.95f)]
    public float scaling = 0.1f;
    [Range(0f,1000f)]
    public float seed;

    public Gradient coloring;

    public GameObject plane;
    
	void Start()
    {
        StartCoroutine(TextureLoop());
        foreach (GradientColorKey key in coloring.colorKeys)
            Debug.Log("new GradientColorKey(new Color(" + key.color.r + "f," + key.color.g + "f," + key.color.b + "f,1f)," + key.time + "f)");
    }
    IEnumerator TextureLoop()
    {
        while (true)
        {
            plane.GetComponent<MeshRenderer>().material.mainTexture = FillTexture();
            yield return new WaitForSeconds(0.5f);
        }
    }
    Texture2D FillTexture()
    {
        Texture2D texture;
        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Perlin Noise L1";
        texture.wrapMode = TextureWrapMode.Clamp;
        if (texture.width != resolution)
            texture.Resize(resolution, resolution);

        for(int x = 0; x < resolution; x++)
        {
            for(int y = 0; y < resolution; y++)
            {
                float newSeed = seed * 1000;
                Vector2 vector = new Vector2((x+newSeed) * scaling, (y+newSeed) * scaling);
                float noise = Sum(vector, frequency, octaves, lacunarity, persistence) * 0.5f + 0.5f;
                Color color = coloring.Evaluate(noise);
                texture.SetPixel(x,y,color);
            }
        }
        texture.Apply();

        return texture;
    }*/
    #region constants
    private static int[] hash = {
        151,160,137, 91, 90, 15,131, 13,201, 95, 96, 53,194,233,  7,225,
        140, 36,103, 30, 69,142,  8, 99, 37,240, 21, 10, 23,190,  6,148,
        247,120,234, 75,  0, 26,197, 62, 94,252,219,203,117, 35, 11, 32,
        57,177, 33, 88,237,149, 56, 87,174, 20,125,136,171,168, 68,175,
        74,165, 71,134,139, 48, 27,166, 77,146,158,231, 83,111,229,122,
        60,211,133,230,220,105, 92, 41, 55, 46,245, 40,244,102,143, 54,
        65, 25, 63,161,  1,216, 80, 73,209, 76,132,187,208, 89, 18,169,
        200,196,135,130,116,188,159, 86,164,100,109,198,173,186,  3, 64,
        52,217,226,250,124,123,  5,202, 38,147,118,126,255, 82, 85,212,
        207,206, 59,227, 47, 16, 58, 17,182,189, 28, 42,223,183,170,213,
        119,248,152,  2, 44,154,163, 70,221,153,101,155,167, 43,172,  9,
        129, 22, 39,253, 19, 98,108,110, 79,113,224,232,178,185,112,104,
        218,246, 97,228,251, 34,242,193,238,210,144, 12,191,179,162,241,
        81, 51,145,235,249, 14,239,107, 49,192,214, 31,181,199,106,157,
        184, 84,204,176,115,121, 50, 45,127,  4,150,254,138,236,205, 93,
        222,114, 67, 29, 24, 72,243,141,128,195, 78, 66,215, 61,156,180,

        151,160,137, 91, 90, 15,131, 13,201, 95, 96, 53,194,233,  7,225,
        140, 36,103, 30, 69,142,  8, 99, 37,240, 21, 10, 23,190,  6,148,
        247,120,234, 75,  0, 26,197, 62, 94,252,219,203,117, 35, 11, 32,
        57,177, 33, 88,237,149, 56, 87,174, 20,125,136,171,168, 68,175,
        74,165, 71,134,139, 48, 27,166, 77,146,158,231, 83,111,229,122,
        60,211,133,230,220,105, 92, 41, 55, 46,245, 40,244,102,143, 54,
        65, 25, 63,161,  1,216, 80, 73,209, 76,132,187,208, 89, 18,169,
        200,196,135,130,116,188,159, 86,164,100,109,198,173,186,  3, 64,
        52,217,226,250,124,123,  5,202, 38,147,118,126,255, 82, 85,212,
        207,206, 59,227, 47, 16, 58, 17,182,189, 28, 42,223,183,170,213,
        119,248,152,  2, 44,154,163, 70,221,153,101,155,167, 43,172,  9,
        129, 22, 39,253, 19, 98,108,110, 79,113,224,232,178,185,112,104,
        218,246, 97,228,251, 34,242,193,238,210,144, 12,191,179,162,241,
        81, 51,145,235,249, 14,239,107, 49,192,214, 31,181,199,106,157,
        184, 84,204,176,115,121, 50, 45,127,  4,150,254,138,236,205, 93,
        222,114, 67, 29, 24, 72,243,141,128,195, 78, 66,215, 61,156,180
    };
    private static Vector2[] gradients2D = {
        new Vector2( 1f, 0f),
        new Vector2(-1f, 0f),
        new Vector2( 0f, 1f),
        new Vector2( 0f,-1f),
        new Vector2( 1f, 1f).normalized,
        new Vector2(-1f, 1f).normalized,
        new Vector2( 1f,-1f).normalized,
        new Vector2(-1f,-1f).normalized
    };
    #endregion
    public static float Sum(Vector2 point, float frequency, int octaves, float lacunarity, float persistence, float multiplicator, float addition)
    {
        float sum = Perlin(point, frequency);
        float amplitude = 1f;
        float range = 1f;
        for(int i = 1; i < octaves; i++)
        {
            frequency *= lacunarity;
            amplitude *= persistence;
            range += amplitude;
            sum += Perlin(point, frequency) * frequency;
        }
        float befResult = sum / range;
        if (befResult * multiplicator > 1f)
            return 1f;
        else
            return (befResult * multiplicator) + addition;
    }
    private static float Dot(Vector2 g, float x, float y)
    {
        return g.x * x + g.y * y;
    }
    private static float Smooth(float t)
    {
        return t * t * t * (t * (t * 6f - 15f) + 10f);
    }
    private static float Perlin(Vector2 point, float frequency)
    {
        point *= frequency;
        int ix0 = Mathf.FloorToInt(point.x);
        int iy0 = Mathf.FloorToInt(point.y);
        float tx0 = point.x - ix0;
        float ty0 = point.y - iy0;
        float tx1 = tx0 - 1f;
        float ty1 = ty0 - 1f;
        ix0 &= 255;
        iy0 &= 255;
        int ix1 = ix0 + 1;
        int iy1 = iy0 + 1;
        int h0 = hash[ix0];
        int h1 = hash[ix1];
        Vector2 g00 = gradients2D[hash[h0 + iy0] & 7];
        Vector2 g10 = gradients2D[hash[h1 + iy0] & 7];
        Vector2 g01 = gradients2D[hash[h0 + iy1] & 7];
        Vector2 g11 = gradients2D[hash[h1 + iy1] & 7];
        float v00 = Dot(g00, tx0, ty0);
        float v10 = Dot(g10, tx1, ty0);
        float v01 = Dot(g01, tx0, ty1);
        float v11 = Dot(g11, tx1, ty1);
        float tx = Smooth(tx0);
        float ty = Smooth(ty0);
        float p0 = Mathf.Lerp(v00, v10, tx);
        float p1 = Mathf.Lerp(v01, v11, tx);
        float f0 = Mathf.Lerp(p0, p1, ty);
        float f1 = f0 * Mathf.Sqrt(2f);
        return f1;
    }
}
