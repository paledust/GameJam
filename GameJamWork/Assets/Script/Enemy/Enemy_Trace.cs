using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trace : EnemyBase {	
	void Start()
	{
		base.Start();
		ColorInitial();
	}
	override protected void MoveInitial()
	{
		originalRotation = transform.rotation;
	}

	//Enemy will copy how the player "control" the ship with different initial speed.
	override protected void Move()
	{
		CopyMovement();
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
