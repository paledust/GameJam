using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager_1 : BossManager {

	override public void BossDestroyAction()
	{
		mainCamera.transform.GetChild(0).GetComponent<Renderer>().material.color -= new Color(0,1,0,0);
		ifDestroyed = true;
	}
}
