using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Round : EnemyBase {
	// Use this for initialization
	override protected void ColorInitial()
	{
		ShipColor = ColorChoose.ColorLibrary[(int)Random.Range(0,ColorChoose.ColorLibrary.Length)];

		GetComponent<SpriteRenderer>().color = ShipColor;
		GetComponent<TrailRenderer>().startColor = ShipColor;
		GetComponent<TrailRenderer>().endColor = ShipColor;
	}

	override protected void MoveInitial()
	{
		circlingRadius = Random.Range(CirclingRange.x, CirclingRange.y);
	}

	override protected void Move()
	{
		if(ifInRange())
		{
			Circling();
		}

		velocity *= 0.99f;
		transform.position += velocity;
	}
}
