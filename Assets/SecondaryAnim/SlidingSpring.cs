using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingSpring : MonoBehaviour {

	public float Spring = 10;
	public float Damping = 1;
	public Vector3 SlidingAxis = new Vector3(0,1,0);
	public float SlidingDistance = 1;
	public float ReactionScale = 1;

	private Vector3 _startPos;
	private Vector3 _lastFrameWorldPos;
	private float _lastFrameVelInAxis;
	private float _currentSlidingPercent;
	private float _currentSlidingSpeed;


	void Start () {
		_startPos = transform.localPosition;
		SlidingAxis.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localVelocity = transform.InverseTransformDirection(_lastFrameWorldPos - transform.position);
		float velInAxis = Vector3.Dot(SlidingAxis, localVelocity) / Time.deltaTime;
		float accel = (velInAxis - _lastFrameVelInAxis) / Time.deltaTime;
		_lastFrameWorldPos = transform.position;
		_lastFrameVelInAxis = velInAxis;

		_currentSlidingSpeed += accel * ReactionScale * Time.deltaTime;

		_currentSlidingSpeed -= Spring * _currentSlidingPercent * Time.deltaTime;
		_currentSlidingSpeed -= Damping * _currentSlidingSpeed * Time.deltaTime;

		_currentSlidingPercent += _currentSlidingSpeed * Time.deltaTime;
		if(Mathf.Abs(_currentSlidingPercent) > 1){
			_currentSlidingPercent = Mathf.Clamp(_currentSlidingPercent, -1, 1);
			_currentSlidingSpeed = 0;
		}
		transform.localPosition = _startPos + SlidingAxis * _currentSlidingPercent * SlidingDistance;
	}
}
