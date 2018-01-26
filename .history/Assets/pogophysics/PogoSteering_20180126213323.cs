using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(PogoPusher))]
public class PogoSteering : MonoBehaviour {

	public float TurningSpeed;
	public float ReducedPushFactor;

	private Rigidbody2D _rigidbody;
	private PogoPusher _pogopusher;
	private float _standardPogoPush;

	void Awake () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_pogopusher = GetComponent<PogoPusher>();
		_standardPogoPush = _pogopusher.MaxPushForce;
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.angularVelocity = Input.GetAxis("Horizontal") * TurningSpeed;
		if(Input.GetButton("Fire1")) {
			_pogopusher.MaxPushForce = _standardPogoPush * ReducedPushFactor;
		}
		else {
			_pogopusher.MaxPushForce = _standardPogoPush;
		}
	}
}
