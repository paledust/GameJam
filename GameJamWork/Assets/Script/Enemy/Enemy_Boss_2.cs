using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_2 : EnemyBase {
	[SerializeField] Transform rotatingTrans;

	public BossManager manager;
	void Start()
	{
		base.Start();
		ifMove = false;
	}

	protected void Update () {
		distanceToPlayer = (player.transform.position - transform.position).magnitude;
		if(ifMove)
		{
			Move();
		}
		rotate();
		if(health <= 0.0f && !ifKill)
		{
			Kill();
			manager.SendMessage("BossDestroyAction");
		}
	}
	override protected void Move()
	{
		Vector3 playerRotateVec = rotatingTrans.position - player.transform.position;
		Vector3 toRotate = rotatingTrans.position - transform.position;

		Vector3 velInMid = toRotate.normalized * Vector2.Dot(player.GetComponent<Control_Force>().getVelocity(), playerRotateVec.normalized);
		Vector3 m_velRound = player.GetComponent<Control_Force>().getVelocity() - 
							playerRotateVec.normalized * Vector3.Dot(player.GetComponent<Control_Force>().getVelocity(), playerRotateVec.normalized);
		
		Vector3 velRound = Quaternion.Euler(0,0,90) * toRotate.normalized * m_velRound.magnitude *
							-Vector3.Cross(m_velRound.normalized, playerRotateVec.normalized).normalized.z;
		velocity = (velRound) * moveSpeed;
		//velocity *= 0.99f;
		GetComponent<Rigidbody2D>().velocity = (Vector2)velocity;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			moveSpeed += 0.5f;
			ApplyDamage(1.0f);
			Vector2 forceDir = collision.gameObject.transform.position - transform.position;
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forceDir.normalized*30, ForceMode2D.Impulse);
		}
	}
}