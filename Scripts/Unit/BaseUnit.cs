using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {
    
	void Start () {
	    Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
	}
    public void GetKey(KeyCode keyCode)
    {

    }
}
