using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(PogoPusher))]
public class PogoSteering : MonoBehaviour {

	public float RotationOffset=10;
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
		_rigidbody.rotation = Input.GetAxis("Horizontal") * RotationOffset;
		if(Input.GetButton("Fire1")) {
			_pogopusher.SpringLength = _standardSpringLength * ReducedSpringLengthFactor;
		}
		else {
			_pogopusher.SpringLength = _standardSpringLength;
		}
	}
}
