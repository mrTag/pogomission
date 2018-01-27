using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postman_visual : MonoBehaviour {

	public GameObject jumper;

	// Use this for initialization
	void Start () {
		this.transform.SetParent(jumper.transform,false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
