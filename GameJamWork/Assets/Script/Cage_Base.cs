using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{
	onEnter = 0,
	onStay = 1,
	OnExit = 2,
	OnExitStay = 3,
};

public class Cage_Base : MonoBehaviour {

	State state;
	private GameObject boss;
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "Boss")
			boss = collider.gameObject;

		state = State.onEnter;
	}

	void OntriggerExit2D(Collider2D collider)
	{
		if(collider.tag == "Boss")
			boss = collider.gameObject;

		state = State.OnExit;
	}

	void OntriggerStay2D(Collider2D collider)
	{
		if(collider.tag == "Boss")
			boss = collider.gameObject;
		
		state = State.onStay;
	}
	
	public GameObject getBoss()
	{
		return boss;
	}

	public State getState()
	{
		return state;
	}
}
