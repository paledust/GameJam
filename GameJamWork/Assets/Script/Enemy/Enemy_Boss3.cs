using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss3 : EnemyBase {
    public BossManager manager;
	protected void Update () {
		if(health <= 0.0f && !ifKill)
		{
			Kill();
			manager.SendMessage("BossDestroyAction");
		}
	}
}
