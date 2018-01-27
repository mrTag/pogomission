using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postman_visual : MonoBehaviour {

	public PogoPusher jumper;
	public Animator PostManAnimator;
	public Vector2 PivotOffset;

	// Use this for initialization
	void Start () {
		this.transform.SetParent(jumper.transform,false);	
		
	}
	
	// Update is called once per frame
	void Update () {
		PostManAnimator.Play("jump", -1, jumper.CurrentSpringFactor);
		PostManAnimator.speed = 0;
		transform.localPosition = PivotOffset + jumper.RelativeFloorOffset;
	}
}
