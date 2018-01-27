using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class RotatingSpring : MonoBehaviour {

	// the higher the Spring the faster it will try to return to the middle.
	// values between 30 and 100 work great!
	public float Spring;

	// Without damping the spring would swing forever.
	// Damping should be between 0.1 and 10.
	public float Damping;
	public float MaxRotationDegrees;
	
	// How much does the worldspace acceleration affect the system?
	public float ReactionScale = 1;

	// to calculate the speed, we need the last position
	private Vector3 _lastFramePosition;
	// to calculate the acceleration, we need the last speed
	private Vector3 _lastFrameSpeed;
	// we do all our springy calculations in a -1 to 1 space and
	// calculate the rotations as a last update step
	private Vector2 _currentRotationFactors;
	private Vector2 _currentRotationSpeed;

	// Use this for initialization
	void Start () {
		_lastFramePosition = transform.position;
		_lastFrameSpeed = Vector3.zero;
		_currentRotationFactors = Vector2.zero;
		_currentRotationSpeed = Vector2.zero;
	}

	// Update is called once per frame
	void Update () {
		Profiler.BeginSample("RotatingSpring");
		// influence from worldacceleration: the acceleration pulls
		// us in the opposite direction
		Vector3 currentSpeed = (transform.position - _lastFramePosition) / Time.deltaTime;
		Vector3 currentAccel = (currentSpeed - _lastFrameSpeed) / Time.deltaTime;
		if(transform.parent != null){
			// we will set our rotation in localspace, so the acceleration
			// should be local, too.
			currentAccel = transform.parent.TransformDirection(currentAccel);
		}
		_currentRotationSpeed.x += -currentAccel.x * ReactionScale * Time.deltaTime;
		_currentRotationSpeed.y += -currentAccel.z * ReactionScale * Time.deltaTime;

		// influence from spring: pulls us back to the center.
		// as the center is 0, the direction to it is minus the position
		_currentRotationSpeed += -_currentRotationFactors * Spring * Time.deltaTime;

		// influence from damping: works against the current speed,
		// slowing us down like dragging through mud
		_currentRotationSpeed += -_currentRotationSpeed * Damping * Time.deltaTime;


		_currentRotationFactors += _currentRotationSpeed * Time.deltaTime;
		if(_currentRotationFactors.sqrMagnitude > 1){
			_currentRotationFactors.Normalize();
		}

		// this one was a little bit trial and error, but it
		// works this way, trust me!
		transform.localRotation = Quaternion.Euler(
			_currentRotationFactors.y * MaxRotationDegrees, 
			0,
			-_currentRotationFactors.x * MaxRotationDegrees);

		_lastFramePosition = transform.position;
		_lastFrameSpeed = currentSpeed;
		Profiler.EndSample();
	}
}
