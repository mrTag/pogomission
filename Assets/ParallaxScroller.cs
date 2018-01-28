using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour {

	public Vector2 ScrollSpeed = new Vector2(1,1);
	public float ZoomSpeed = 1;
	public Transform Camera;

	
	private Vector3 _startPosition;
	private float _startZoom;
	private Camera _cam;

	void Start () {
		_startPosition = transform.position;
		_cam = Camera.GetComponent<Camera>();
		_startZoom = _cam.orthographicSize;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 camOffsetToStart = Camera.position - _startPosition;
		transform.position = _startPosition + Vector3.Scale(ScrollSpeed, camOffsetToStart);
		transform.localScale = Vector3.one - Vector3.one * Mathf.InverseLerp(_startZoom, _startZoom * 2, _cam.orthographicSize) * ZoomSpeed; 
	}
}
