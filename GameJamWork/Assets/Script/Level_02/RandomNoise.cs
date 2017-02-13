using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoise : MonoBehaviour {
	private float coolDown;
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
		int i = Random.Range(0,20);
		coolDown = i;
		timer += Time.deltaTime;
		if(timer >= coolDown)
		{
			timer = 0.0f;
			if(i>=10)
			{
				audioSource.Pause();
				GetComponent<SpriteRenderer>().color = new Color(1,1,1,Random.Range(0.0f,0.4f));
			}
			else
			{
				audioSource.Play();
				GetComponent<SpriteRenderer>().color = new Color(1,1,1,Random.Range(0.5f,1.0f));
			}
		}
	}
}
