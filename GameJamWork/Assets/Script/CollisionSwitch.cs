using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSwitch : MonoBehaviour {

	// Use this for initialization

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.tag == "Player")
		{
			Debug.Log("asdfadsf");
			GetComponent<Collider2D>().isTrigger = false;
		}
	}
}
