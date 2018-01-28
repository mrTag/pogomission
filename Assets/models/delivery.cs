using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class delivery : MonoBehaviour {

	public Transform MyPackage;
	public AudioSource AudioDelivered;

	public event System.Action Done = delegate{};

	void Start() {
		MyPackage.localPosition = new Vector3(0,10,0);
	}

	void OnEnable() {
		MyPackage.DOLocalMoveY(0,0.2f).SetEase(Ease.Linear).OnComplete(() => {
			Done();
		});
		AudioDelivered.Play();

	}
	void OnDisable() {
		MyPackage.localPosition = new Vector3(0,10,0);
	}
}
