﻿using System.Collections;
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

	private Rigidbody2D _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 worldSpaceStart = transform.TransformPoint(SpringStartOffset);
		Vector2 worldSpaceDir = transform.TransformDirection(SpringDirection);
		Debug.DrawLine(worldSpaceStart, worldSpaceStart + worldSpaceDir * SpringLength);
		var raycastHit = Physics2D.Raycast(worldSpaceStart, worldSpaceDir, SpringLength, CollisionLayerMask);

		if(raycastHit){
			float distanceFactor = Mathf.Pow((1.0f - raycastHit.fraction), PushExpo);
			_rigidbody.AddForceAtPosition(-worldSpaceDir * MaxPushForce * Time.fixedDeltaTime * distanceFactor, worldSpaceStart);

			Vector2 velAtPogoTip = _rigidbody.GetPointVelocity(raycastHit.point);
			Vector2 perpNormal = new Vector2(-raycastHit.normal.y, raycastHit.normal.x);
			Vector2 perpNormalVel = perpNormal * Vector2.Dot(velAtPogoTip, perpNormal);
			_rigidbody.AddForceAtPosition(-perpNormalVel/(Time.fixedDeltaTime * 10), raycastHit.point);
		}
	}
}
