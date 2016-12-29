using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapPlotter {
    
    public static void PlotBase(Map map, Transform holder)
    {
        for(int x = 0; x < map.Size(0); x++)
            for(int y = 0; y < map.Size(1); y++)
            {
                GameObject createdTile = new GameObject("Tile - Base (" + map.tiles[x, y].tileValue + ")");
                createdTile.transform.position = map.tiles[x, y].positionGrid; //let's just go with this without the scalar for now, TODO add scalar
                createdTile.transform.SetParent(holder, true);
                map.tiles[x, y].associatedGOBase = createdTile;
                SpriteRenderer renderer = createdTile.AddComponent<SpriteRenderer>();
                renderer.sprite = ReferentStatic.ReferentDynamic().TexturesBase[0];
            }
        Debug.Log("Propably done plotting map"); //TODO remove and cleanup
    }

}
