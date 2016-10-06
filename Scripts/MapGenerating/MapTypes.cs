using UnityEngine;
using System.Collections;

public static class MapTypes {
    private static GradientAlphaKey[] alpha_keys = new GradientAlphaKey[]
    {
        new GradientAlphaKey(1f,0f),
        new GradientAlphaKey(1f,1f)
    };

    public static GeneratorType NormalLake
    {
        get
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(new Color(0f,0f,1f,1f),0.4010986f),
                new GradientColorKey(new Color(1f,1f,0f,1f),0.4093385f),
                new GradientColorKey(new Color(0f,1f,0f,1f),0.4303960f),
                new GradientColorKey(new Color(0f,1f,0f,1f),0.9f),
                new GradientColorKey(new Color(0f,0.408f,0f,1f),0.95f)
            };
            Gradient coloring = new Gradient();
            coloring.alphaKeys = alpha_keys;
            coloring.colorKeys = colorKeys;
            return new GeneratorType(256, 1, 0.7f, 1.83f, 0.32f, 0.2f, coloring, 1.06f, 0.466f);
        }
    }
}
