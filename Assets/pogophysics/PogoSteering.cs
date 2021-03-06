﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(PogoPusher))]
public class PogoSteering : MonoBehaviour {

	public float MaxTorque=100;
	public float MaxRotation = 10;
	public float MaxPOffset = 5;
	public float MaxDOffset = 5;
	public float DAmount = 0.3f;
	public float ReducedSpringLengthFactor;

	private Rigidbody2D _rigidbody;
	private PogoPusher _pogopusher;
	private float _standardSpringLength;

	void Awake () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_pogopusher = GetComponent<PogoPusher>();
		_standardSpringLength = _pogopusher.SpringLength;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float targetRotation = -Input.GetAxis("Horizontal") * MaxRotation;
		float rotationOffset = targetRotation - _rigidbody.rotation;
		float pFactor = Mathf.InverseLerp(0, MaxPOffset, Mathf.Abs(rotationOffset)) * Mathf.Sign(rotationOffset);
		float dFactor = Mathf.InverseLerp(0, MaxDOffset, Mathf.Abs(_rigidbody.angularVelocity)) * -Mathf.Sign(_rigidbody.angularVelocity);

		float torqueFactor = pFactor + DAmount * dFactor;
		_rigidbody.AddTorque(torqueFactor * MaxTorque * Time.fixedDeltaTime);


		if(Input.GetButton("Fire1")) {
			_pogopusher.SpringLength = _standardSpringLength * ReducedSpringLengthFactor;
		}
		else {
			_pogopusher.SpringLength = _standardSpringLength;
		}
	}
}
