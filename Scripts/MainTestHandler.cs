using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainTestHandler : MonoBehaviour {

    public Vector2 offset;
    public Vector2 count;
    public GameObject hexagonPrefab;
    public GameObject hexaGridParent;

    private List<GameObject> createdObjects = new List<GameObject>();
    
    void Start()
    {
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
                SpriteRenderer sr = created.GetComponent<SpriteRenderer>();
                sr.color = Random.ColorHSV();
                created.transform.SetParent(hexaGridParent.transform, true);
                createdObjects.Add(created);
            }
        }
        float xPos = (count.x * offset.x) / 2f;
        float yPos = (count.y * offset.y) / 2f;
        Camera.main.transform.position = new Vector3(xPos, yPos, -10);
    }
    bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}
