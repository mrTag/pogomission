using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class delivery : MonoBehaviour {

	public Transform MyPackage;

	void Start() {
		MyPackage.localPosition = new Vector3(0,10,0);
	}

	void OnEnable() {		
		MyPackage.DOLocalMoveY(0,0.4f);

	}
	void OnDisable() {		
		MyPackage.localPosition = new Vector3(0,10,0);
	}
}
