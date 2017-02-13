using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChange : MonoBehaviour {
	private float timer;
	private float coolDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float i = Random.Range(0.0f, 2.0f);
		coolDown = i;
		timer += Time.deltaTime;
		if(timer >= coolDown)
		{
			timer = 0.0f;
			transform.localScale = new Vector3(0.3f,Random.Range(0.01f,1f),1);
		}
	}
}
