using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour {

    protected uint _healthPoints;
    protected uint _maxHealth;
    protected uint _maxMoves;
    protected uint _movesLeft;

	void Start () {
	    Referent referent = GameObject.FindGameObjectWithTag("referent").GetComponent<Referent>();
	}
    public void GetKey(KeyCode keyCode)
    {

    }
}
