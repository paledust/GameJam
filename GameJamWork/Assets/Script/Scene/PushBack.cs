using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour {
	public float AddForce;
	private Rigidbody2D rigidBody;
	// Use this for initialization
	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.tag == "Player")
		{
			collider.gameObject.GetComponent<Rigidbody2D>().velocity += (Vector2)(transform.position - collider.transform.position).normalized * AddForce;
		}
	}
}
