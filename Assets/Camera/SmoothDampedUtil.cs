using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampedValue {
	public float Target;
	public float Current { get; private set; }
	public float MinTime;
	private float _velocity;

	public SmoothDampedValue(float initValue, float minTime) {
		Target = Current = initValue;
		MinTime = minTime;
	}

	public void DoUpdate () {
		Current = Mathf.SmoothDamp(Current, Target, ref _velocity, MinTime);
	}
}

public class SmoothDampedVector3 {
	public Vector3 Target;
	public Vector3 Current { get; private set; }
	public float MinTime;
	private Vector3 _velocity;

	public SmoothDampedVector3(Vector3 initVector, float minTime) {
		Target = Current = initVector;
		MinTime = minTime;
	}

	public void DoUpdate () {
		Current = Vector3.SmoothDamp(Current, Target, ref _velocity, MinTime);
	}
}