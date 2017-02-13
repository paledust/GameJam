using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSlow : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Control_Force>().speed > 0.02f)
		{
			collision.gameObject.GetComponent<Control_Force>().speed -= 0.02f;
		}
	}
}
