using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
	public GameObject boss;
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "Player")
		{
			boss.GetComponent<EnemyBase>().SetMove(true);
		}
	}
}
