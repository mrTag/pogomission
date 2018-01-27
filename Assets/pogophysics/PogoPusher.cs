using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PogoPusher : MonoBehaviour {

	public Vector2 SpringStartOffset;
	public Vector2 SpringDirection = new Vector2(0, -1);
	public LayerMask CollisionLayerMask = -1;
	public float SpringLength = 0.5f;
	public float MaxPushForce = 10;
	public float PushExpo = 2;
	public float SpringVelocity { get; private set; }

	public Vector2 RelativeFloorOffset {
		get {
			return SpringStartOffset + SpringDirection * _currentSpringLength;
		}
	}

	private float _startSpringLength;
	private float _currentSpringLength;
	public float CurrentSpringFactor {
		get {
			return _currentSpringLength / _startSpringLength;
		}
	}

	private Rigidbody2D _rigidbody;

	void Awake()
	{
		_startSpringLength = SpringLength;
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 worldSpaceStart = transform.TransformPoint(SpringStartOffset);
		Vector2 worldSpaceDir = transform.TransformDirection(SpringDirection);
		//Debug.DrawLine(worldSpaceStart, worldSpaceStart + worldSpaceDir * SpringLength);
		var raycastHit = Physics2D.Raycast(worldSpaceStart, worldSpaceDir, SpringLength, CollisionLayerMask);

		if(raycastHit){
			float lastSpringLength = _currentSpringLength;
			_currentSpringLength = (raycastHit.point - worldSpaceStart).magnitude;
			SpringVelocity = (lastSpringLength - _currentSpringLength) / Time.fixedDeltaTime;
			float distanceFactor = Mathf.Pow((1.0f - raycastHit.fraction), PushExpo);
			_rigidbody.AddForceAtPosition(-worldSpaceDir * MaxPushForce * Time.fixedDeltaTime * distanceFactor, raycastHit.point);

			Vector2 velAtPogoTip = _rigidbody.GetPointVelocity(raycastHit.point);
			Vector2 perpNormal = new Vector2(-raycastHit.normal.y, raycastHit.normal.x);
			Vector2 perpNormalVel = perpNormal * Vector2.Dot(velAtPogoTip, perpNormal);
			_rigidbody.AddForceAtPosition(-perpNormalVel/(Time.fixedDeltaTime * 20), raycastHit.point);
		} else {
			SpringVelocity = 0f;
			_currentSpringLength = SpringLength;
		}
	}
}
