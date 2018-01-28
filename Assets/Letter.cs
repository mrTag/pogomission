using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Letter : MonoBehaviour {

	public static event Action Delivered = delegate {};

	public Collider2D MailboxCollider;
	public Rigidbody2D MailManRigidbody;
	public Transform MailboxFlag;
	public ParticleSystem LetterParticles;
	public GameObject FinalTouch;

	void OnTriggerEnter2D(Collider2D other) {
		if (other == MailboxCollider) {
			Debug.Log("Letter Delivered");
			MailManRigidbody.simulated = false;
			Delivered();
			MailboxFlag.DORotate(new Vector3(0f, 0f, -90f), 1.5f).SetDelay(1.5f).OnStart(() => {
				MailboxFlag.GetComponent<AudioSource>().Play();
			});
			LetterParticles.Stop();
			if (FinalTouch != null) {
				//FinalTouch.SetActive(true);
			}
			gameObject.SetActive(false);
		}
	}
}
