﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVisualize : MonoBehaviour {
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(audioSource.clip.frequency);
	}
}
