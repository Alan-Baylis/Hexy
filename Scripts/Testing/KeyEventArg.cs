using UnityEngine;
using System.Collections;
using System;

public class KeyEventArg : EventArgs {

    public readonly KeyCode keycode;
    public KeyEventArg(KeyCode val)
    {
        keycode = val;
    }
}
