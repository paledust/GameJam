using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbDisappear : MonoBehaviour {
	public AudioClip[] Audioclips;
	public AudioSource AmbientAudio;
	private AudioClip playingClip;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "Player")
		{
			int i = Random.Range(0,Audioclips.Length);

			playingClip = Audioclips[i];
			GetComponent<AudioSource>().PlayOneShot(playingClip);
			collider.gameObject.GetComponent<Control_Force>().speed += 0.02f;

			AmbientAudio.volume -= 0.04f;
			Kill();
		}
	}

	void Kill()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		Destroy(gameObject,3.0f);
	}
}
