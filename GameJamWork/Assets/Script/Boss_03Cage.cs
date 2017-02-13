using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_03Cage : MonoBehaviour {

	public float TimeDelay;
	private float timer;
	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.tag == "Boss")
		{
			Debug.Log("Hi");
			float distance = (collider.gameObject.transform.position - transform.position).magnitude;
			Debug.Log(distance);
			if(distance <= 10.0f)
			{	
				timer += Time.deltaTime;
				if(timer >= TimeDelay)
				{
					collider.gameObject.GetComponent<EnemyBase>().ApplyDamage(1.0f);
				}
			}
			else
			{
				timer = 0.0f;
			}
		}
	}
}
