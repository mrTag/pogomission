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
	public delivery FinalTouch;

	void OnTriggerEnter2D(Collider2D other) {
		if (other == MailboxCollider) {
			Debug.Log("Letter Delivered");
			MailManRigidbody.simulated = false;
			MailboxFlag.DORotate(new Vector3(0f, 0f, -90f), 1.5f).SetDelay(1.5f).OnStart(() => {
				MailboxFlag.GetComponent<AudioSource>().Play();
			}).OnComplete(() => {
				if (FinalTouch != null) {
					FinalTouch.Done += () => { 
						Delivered();
						if (WishMaster.Instance != null && !string.IsNullOrEmpty(WishMaster.Instance.SelectedWishID)) {
                            WishMaster.Instance.FullfillWish(WishMaster.Instance.SelectedWishID, WishMaster.Instance.PlayerName);
                        }
					};
					FinalTouch.gameObject.SetActive(true);
				}
			});
			LetterParticles.Stop();
			gameObject.SetActive(false);
		}
	}
}
