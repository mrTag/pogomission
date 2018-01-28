using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class post_ui : MonoBehaviour {

	public Transform Manual;
	bool isOpen;

	void Start () {
		Manual.localPosition = new Vector3(0,-650,0);
		isOpen = false;
	}

	public void ToggleManual() {
		if (isOpen) {
			isOpen = false;
			Manual.DOLocalMoveY(-650,1).SetEase(Ease.OutBack);
			
		} else {
			isOpen = true;
			Manual.DOLocalMoveY(60,1).SetEase(Ease.OutBack);
		}
	}

	
}
