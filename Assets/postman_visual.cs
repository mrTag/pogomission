using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postman_visual : MonoBehaviour {

	public PogoPusher jumper;
	public Animator PostManAnimator;
	public Animator BagAnimator;
	public Vector2 PivotOffset;
	public ParticleSystem PFX_Dust;
	private float particleThresholdVelocity = 6;

	// Use this for initialization
	void Start () {
		this.transform.SetParent(jumper.transform,false);	
		
	}
	
	// Update is called once per frame
	void Update () {
		PostManAnimator.Play("jump", -1, jumper.CurrentSpringFactor);
		PostManAnimator.speed = 0;
		BagAnimator.Play("jump", -1, jumper.CurrentSpringFactor);
		BagAnimator.speed = 0;
		transform.localPosition = PivotOffset + jumper.RelativeFloorOffset;

		if (jumper.SpringVelocity >= particleThresholdVelocity) {

			PFX_Dust.Emit(Mathf.FloorToInt((jumper.SpringVelocity-particleThresholdVelocity)*3));
		}
		
	}
}
