using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring2D : MonoBehaviour {

	public Vector2 SpringSamplingPoint;
	public float Spring = 10;
	public float Damping = 5;
	public float MaxAngle = 20;
	public float RotationAccel = 10;
	public float AccelReactionFactor = 20;

	private Vector2 _lastFramePos;
	private Vector2 _lastFrameVel;
	private float _currentRotationSpeed;
	private float _currentAngle;

	void Start() {
		_lastFramePos = transform.TransformPoint(SpringSamplingPoint);
	}

	void Update(){
		Vector2 samplingPointWorld = transform.TransformPoint(SpringSamplingPoint);
		Vector2 currentVel = (samplingPointWorld - _lastFramePos) / Time.deltaTime;
		Vector2 accel = (currentVel - _lastFrameVel) / Time.deltaTime;
		Debug.DrawLine(samplingPointWorld, samplingPointWorld + currentVel * 20);
		accel = transform.parent.TransformDirection(accel);
		_lastFrameVel = currentVel;
		_lastFramePos = samplingPointWorld;

		Vector2 perpDirToSamplingPoint = samplingPointWorld - (Vector2)transform.position;
		perpDirToSamplingPoint.Normalize();
		perpDirToSamplingPoint = new Vector2(perpDirToSamplingPoint.y, -perpDirToSamplingPoint.x);

		

		float perpAccel = Vector2.Dot(perpDirToSamplingPoint, accel);
		_currentRotationSpeed += perpAccel * Time.deltaTime * AccelReactionFactor;

		float springValue = -(_currentAngle / MaxAngle) * Spring;
		
		float dampingValue = -_currentRotationSpeed * Damping;

		float torque = RotationAccel * (springValue + dampingValue);
		_currentRotationSpeed += torque * Time.deltaTime;
		_currentAngle += _currentRotationSpeed * Time.deltaTime;
		_currentAngle = Mathf.Clamp(_currentAngle, -MaxAngle, MaxAngle);
		transform.localEulerAngles = new Vector3(0, 0, _currentAngle);
	}

	void OnDrawGizmos()
	{
		Vector2 pointOffset = (Vector2.up + Vector2.left) * 0.25f;
		Vector2 samplingPointWorld = transform.TransformPoint(SpringSamplingPoint);
		Gizmos.DrawLine(samplingPointWorld+pointOffset, samplingPointWorld-pointOffset);
		pointOffset.x *=-1;
		Gizmos.DrawLine(samplingPointWorld + pointOffset, samplingPointWorld - pointOffset);
	}
}
