using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Round : EnemyBase {
	override protected void MoveInitial()
	{
		transform.rotation = Quaternion.Euler(0,0,Random.Range(0,180.0f));
		circlingRadius = Random.Range(CirclingRange.x, CirclingRange.y);
	}

	override protected void Move()
	{
		if(ifInRange())
		{
			Circling();
		}

		velocity *= 0.99f;
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
