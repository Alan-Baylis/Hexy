using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Referent : MonoBehaviour {
    public GameObject GOMapParent;
    public GameObject PFHexagonTileBlank;
    public GameObject[,] ArrayMap;
    public Sprite[] TexturesBase = new Sprite[5];

    public event EventHandler<KeyEventArg> KeyDown;

    void OnGUI()
    {
        if(KeyDown!=null)
            KeyDown.Invoke(this, new KeyEventArg(Event.current.keyCode));
    }
    
}
