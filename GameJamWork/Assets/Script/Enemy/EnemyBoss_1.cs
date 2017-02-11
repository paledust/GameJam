using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1 : EnemyBase {
	// Update is called once per frame

	override protected void Move()
	{
		if(ifInRange())
		{
			Vector2 playerVector = (Vector2)(transform.position - player.transform.position);

			if(Vector2.Dot(player.GetComponent<Rigidbody2D>().velocity, playerVector) >= 0.0f)
			{
				StayAway();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Enemy_Round>())
		{
			ApplyDamage(1.0f);
			collision.gameObject.GetComponent<Enemy_Round>().ApplyDamage(1.0f);
		}
	}
}
