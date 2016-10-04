using UnityEngine;
using System.Collections;

public class PerlinNoiseGenerator : MonoBehaviour {


    public int resolution;
    public GameObject plane;

    private Texture2D texture;
	void OnEnable()
    {
        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Perlin Noise L1";
        plane.GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
}
