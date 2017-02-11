using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour {
	[SerializeField] float MaxScale;
	[SerializeField] float DetectRange;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = (player.transform.position - transform.position).magnitude;
		if(distance <= DetectRange)
		{
			transform.localScale = Vector3.Lerp(Vector3.one * MaxScale, Vector3.zero, distance/DetectRange);
		}
	}
}
