using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveHandler {

    public static void SaveMap(Map map, string filename)
    {
        List<string> toSave = new List<string>();
        toSave.Add("Map_Save");
        toSave.Add("Dimensions: " + map.Size(0) + "x" + map.Size(1));
        for(int x = 0; x < map.Size(0); x++)
            for(int y = 0; y < map.Size(1); y++)
            {
                MapTile tile = map.tiles[x, y];
                string line = "|" + x + "|" + y + "|" + tile.tileValue + "|";
                if (tile.associatedGOBase == null)
                    line += "false|";
                else
                    line += "true|";
                toSave.Add(line);
            }
        toSave.Add("Map_Save_End");
        File.WriteAllLines(filename, toSave.ToArray());
    }
    public static Map LoadMap(string filename)
    {
        string[] loaded = File.ReadAllLines(filename);
        string dimensionLine = loaded[1];
        string[] splitted = dimensionLine.Split('x');
        string lenX = splitted[0].Split(' ')[1];
        string lenY = splitted[1];

        Map toReturn = new Map(int.Parse(lenX), int.Parse(lenY));

        for(int i = 2; i < loaded.Length - 1; i++)
        {
            splitted = loaded[i].Split('|');
            string posX = splitted[1];
            string posY = splitted[2];
            string value = splitted[3];

            toReturn.tiles[int.Parse(posX), int.Parse(posY)] = new MapTile(float.Parse(value), new Vector2(int.Parse(posX), int.Parse(posY)));
        }

        return toReturn;
    }
}
