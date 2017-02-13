using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BossManager_1 : BossManager {

	override public void BossDestroyAction()
	{
		mainCamera.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1,0,1,1); 
	}
}
