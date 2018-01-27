using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour {

	public Vector2 ScrollSpeed = new Vector2(1,1);
	public Transform Camera;
	
	private Vector3 _startPosition;
	void Start () {
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 camOffsetToStart = Camera.position - _startPosition;
		transform.position = _startPosition + Vector3.Scale(ScrollSpeed, camOffsetToStart);
	}
}
