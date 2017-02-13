using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBuild : MonoBehaviour {
	private LineRenderer lineRenderer;

	public Transform[] joints;
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetPosition(0, joints[0].position);
		lineRenderer.SetPosition(1, joints[1].position);
	}
}
