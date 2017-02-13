using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager_3 : BossManager {

	// Use this for initialization
	override public void BossDestroyAction()
	{
		mainCamera.transform.GetChild(0).GetComponent<Renderer>().material.color -= new Color(1,0,0,0); 

		ifDestroyed = true;
	}
}
