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
    public event EventHandler<MouseEventArg> MouseDown, MouseHeld, MouseReleased;

    void OnGUI()
    {
        if(KeyDown!=null)
            KeyDown.Invoke(this, new KeyEventArg(Event.current.keyCode));
    }

    //bool mouse_down = false;
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*if (mouse_down && !Input.GetMouseButton(0))
        {
            mouse_down = false;
            MouseReleased.Invoke(this, new MouseEventArg(pos, 0));
        }else if(!mouse_down && Input.GetMouseButton(0))
        {
            mouse_down = true;
            MouseDown.Invoke(this, new MouseEventArg(pos, 0));
        }else if(mouse_down && Input.GetMouseButton(0))
        {
            MouseHeld.Invoke(this, new MouseEventArg(pos, 0));
        }*/
        if(Input.GetMouseButtonDown(0))
            MouseDown.Invoke(this, new MouseEventArg(pos, 0));
        else if(Input.GetMouseButton(0))
            MouseHeld.Invoke(this, new MouseEventArg(pos, 0));
        else if(Input.GetMouseButtonUp(0))
            MouseReleased.Invoke(this, new MouseEventArg(pos, 0));
    }
}
