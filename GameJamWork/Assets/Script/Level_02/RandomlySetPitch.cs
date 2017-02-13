using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySetPitch : MonoBehaviour {
	public float coolDown;
	private float timer;
	public Vector2 PitchChange;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		int i = Random.Range(4,20);
		coolDown = i;
		timer += Time.deltaTime;
		if(timer >= coolDown)
		{
			timer = 0.0f;
			RandomPitchMode();
		}
	}

	public float getPitch()
	{
		return audioSource.pitch;
	}

	void RandomPitchMode()
	{
		audioSource.pitch = Random.Range(1.0f,3.0f);
	}

	public void setPitch(float _pitch)
	{
		audioSource.pitch = _pitch;
	}
}
