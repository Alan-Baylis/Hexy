using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Referent : MonoBehaviour {
    public GameObject GOMapParent;
    public GameObject PFHexagonTileBlank;
    public GameObject[,] ArrayMap;
    public Sprite[] TexturesBase = new Sprite[5];
    public Map map;
    public Text textSeed;

    public event EventHandler<KeyEventArg> KeyDown;
    public event EventHandler<MouseEventArg> MouseClicked;

    void OnGUI()
    {
        if(KeyDown!=null)
            KeyDown.Invoke(this, new KeyEventArg(Event.current.keyCode));
    }
    void Update()
    {
        if (MouseClicked != null && Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MouseClicked.Invoke(this, new MouseEventArg(pos, 0));
        }
    }
}
