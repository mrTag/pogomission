using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoSounds : MonoBehaviour {

	public float PlayVelocityThreshold;
	public AudioSource SpringDown;
	public AudioSource SpringUp;
	private PogoPusher _pusher;

	public AudioClip[] DownSounds;
	public AudioClip[] UpSounds;

	void Start () {
		_pusher = GetComponent<PogoPusher>();
	}
	
	void Update () {
		if (Mathf.Abs(_pusher.SpringVelocity) > PlayVelocityThreshold) {
			if (_pusher.SpringVelocity > 0f && !SpringDown.isPlaying) {
				PlayDown();
			}
			else if (_pusher.SpringVelocity < 0f && !SpringUp.isPlaying) {
				PlayUp();
			}
		}
	}

	private void PlayDown() {
		SpringDown.clip = DownSounds[Random.Range(0, DownSounds.Length)];
		SpringDown.pitch = Random.Range(.95f, 1.05f);
		SpringDown.volume = Mathf.InverseLerp(0f, 15f, Mathf.Abs(_pusher.SpringVelocity));
		SpringDown.Play();
	}

	private void PlayUp() {
		//Debug.Log("up: " + _pusher.SpringVelocity);
		SpringUp.clip = UpSounds[Random.Range(0, DownSounds.Length)];
		SpringUp.pitch = Random.Range(.95f, 1.05f);
		SpringUp.volume = Mathf.InverseLerp(0f, 15f, Mathf.Abs(_pusher.SpringVelocity));
		SpringUp.Play();
	}
}
