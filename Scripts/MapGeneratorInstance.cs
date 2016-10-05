using UnityEngine;
using System.Collections;

public class MapGeneratorInstance {

    

    private int _resolution, _octaves;
    private float _frequency, _lacunarity, _persistence, _scaling, _seed;
    private Gradient _coloring;

    public int resolution {
        get
        {
            return _resolution;
        }
    }
    public int octaves
    {
        get
        {
            return _octaves;
        }
    }
    public float frequency
    {
        get
        {
            return _frequency;
        }
    }
    public float lacunarity
    {
        get
        {
            return _lacunarity;
        }
    }
    public float persistence
    {
        get
        {
            return _persistence;
        }
    }
    public float scaling
    {
        get
        {
            return _scaling;
        }
    }
    public float seed
    {
        get
        {
            return _seed;
        }
    }
    public Gradient coloring
    {
        get
        {
            return _coloring;
        }
    }

    public MapGeneratorInstance(int resolution, int octaves, float frequency, float lacunarity, float persistence, float scaling, float seed, Gradient coloring)
    {
        _resolution = resolution;
        _octaves = octaves;
        _frequency = frequency;
        _lacunarity = lacunarity;
        _persistence = persistence;
        _scaling = scaling;
        _seed = seed;
        _coloring = coloring;
    }

}