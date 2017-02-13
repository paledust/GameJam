using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {
	public GameObject boss;
	static protected Camera mainCamera;

	protected void Start()
	{
		mainCamera = Camera.main;
	}
	virtual public void BossDestroyAction()
	{
		
	}

	virtual public void BossAttackedAction()
	{
		
	}

	virtual public void BossOtherAction()
	{

	}
}
