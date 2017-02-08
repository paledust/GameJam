using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {
	public float MaxForce;
	[SerializeField]private float previousSpeed;

	void OnTriggerStay2D(Collider2D collider)
	{
		Debug.Log("Happen");
		if(collider.tag == "Player")
		{
			collider.gameObject.GetComponent<Control_Force>().ApplyForce(Vector2.left*MaxForce);
		}
	}
}
