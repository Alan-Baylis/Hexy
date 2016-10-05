using UnityEngine;
using System.Collections;

public static class MapTypes {

    private static GradientAlphaKey[] Template_ak = new GradientAlphaKey[]
    {
        new GradientAlphaKey(1f,0f),
        new GradientAlphaKey(1f,1f)
    };

    public static MapGeneratorInstance TemplateLakes
    {
        get
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(new Color(0f,0f,1f,1f),0.4010986f),
                new GradientColorKey(new Color(1f,1f,0f,1f),0.4093385f),
                new GradientColorKey(new Color(0f,1f,0f,1f),0.4303960f),
                //new GradientColorKey(new Color(0f,1f,0f,1f),0.6346227f),
                //new GradientColorKey(new Color(0f,0.408f,0f,1f),0.7976196f)
                new GradientColorKey(new Color(0f,1f,0f,1f),0.9f),
                new GradientColorKey(new Color(0f,0.408f,0f,1f),0.95f)
            };
            Gradient coloring = new Gradient();
            coloring.alphaKeys = Template_ak;
            coloring.colorKeys = colorKeys;
            //return new MapGeneratorInstance(256, 1, 0.7f, 1.83f, 0.32f, 0.018f, 204f, coloring);
            return new MapGeneratorInstance(256, 1, 0.7f, 1.83f, 0.32f, 0.2f, 204f, coloring, 1.06f, 0.466f);
        }
    }
    public static MapGeneratorInstance TemplateSmoothNoLakes
    {
        get
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(new Color(0f,1f,0f,1f),0.6126345f),
                new GradientColorKey(new Color(0f,0.408f,0f,1f),0.8058594f)
            };
            Gradient coloring = new Gradient();
            coloring.alphaKeys = Template_ak;
            coloring.colorKeys = colorKeys;
            return new MapGeneratorInstance(256, 1, 0.7f, 1.83f, 0.32f, 0.018f, 204f, coloring, 1f, 0f);
        }
    }
    public static MapGeneratorInstance TemplateMountains
    {
        get
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(new Color(0f,1f,0f,1f),0.1868162f),
                new GradientColorKey(new Color(0f,0.4078431f,0f,1f),0.376379f)
            };
            Gradient coloring = new Gradient();
            coloring.alphaKeys = Template_ak;
            coloring.colorKeys = colorKeys;
            return new MapGeneratorInstance(256, 1, 0.7f, 1.83f, 0.32f, 0.018f, 204f, coloring, 1f, 0f);
        }
    }
    public static MapGeneratorInstance TemplateFlat
    {
        get
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(new Color(0f,1f,0f,1f),0f),
                new GradientColorKey(new Color(0f,1f,0f,1f),1f)
            };
            Gradient coloring = new Gradient();
            coloring.alphaKeys = Template_ak;
            coloring.colorKeys = colorKeys;
            return new MapGeneratorInstance(256, 1, 0.7f, 1.83f, 0.32f, 0.018f, 204f, coloring, 1f, 0f);
        }
    }
}
