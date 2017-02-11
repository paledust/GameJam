using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_2 : EnemyBase {
	[SerializeField] Transform rotatingTrans;
	override protected void Move()
	{
		Vector2 playerRotateVec = player.transform.position - rotatingTrans.position;
		Vector2 toRotate = rotatingTrans.transform.position - transform.position;

		Vector2 velInMid = toRotate.normalized * Vector2.Dot(player.GetComponent<Control_Force>().getVelocity(), playerRotateVec.normalized);
		Vector2 velRound = -(Vector2)player.GetComponent<Control_Force>().getVelocity() - 
							playerRotateVec.normalized * Vector2.Dot(player.GetComponent<Control_Force>().getVelocity(), playerRotateVec.normalized);
		velocity = velInMid + velRound;
		velocity *= 0.99f;
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}