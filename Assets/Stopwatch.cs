using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {

	private Text _countDownText;
	private float _startTime;
	private bool _active = true;

	void Awake() {
		_countDownText = GetComponent<Text>();
		StartTimer();
		Letter.OnDelivery += StopTimer;
	}

	public void StartTimer() {
		_startTime = Time.time;
		_active = true;
	}

	public void StopTimer() {
		_active = false;
	}

	void Update(){
		if (_active) {
			float currentTimeSeconds = Time.time - _startTime;
			_countDownText.text = string.Format("{0:00}:{1:00}.{2:00}", (int)(currentTimeSeconds / 60), (int)(currentTimeSeconds % 60), (int)(currentTimeSeconds % 1.0f * 100.0f));
		}
	}
}
