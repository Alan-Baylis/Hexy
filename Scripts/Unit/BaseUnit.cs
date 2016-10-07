using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {
    
	void Start () {
	    Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
        referent.KeyDown += (s,c) => { GotKey((KeyCode)s); };
	}
    void GotKey(KeyCode code)
    {
        Debug.Log("We got key!!!");
    }
}
