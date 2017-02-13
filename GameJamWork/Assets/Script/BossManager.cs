using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {
	public GameObject boss;
	static protected Camera mainCamera;

	public bool ifDestroyed = false;
	protected void Start()
	{
		mainCamera = Camera.main;
		ifDestroyed = false;
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
