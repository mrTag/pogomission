using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(PogoPusher))]
public class PogoSteering : MonoBehaviour {

	public float TurningSpeed;
	public float ReducedPushExpo;

	private Rigidbody2D _rigidbody;
	private PogoPusher _pogopusher;
	private float _standardPogoExpo;

	void Awake () {
		_rigidbody = GetComponent<Rigidbody2D>();
		_pogopusher = GetComponent<PogoPusher>();
		_standardPogoExpo = _pogopusher.PushExpo;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rigidbody.angularVelocity = Input.GetAxis("Horizontal") * TurningSpeed;
		if(Input.GetButton("Fire1")) {
			_pogopusher.PushExpo = _standardPogoExpo * ReducedPushExpo;
		}
		else {
			_pogopusher.PushExpo = _standardPogoExpo;
		}
	}
}
