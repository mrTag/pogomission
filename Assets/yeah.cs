using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeah : MonoBehaviour {

	public AudioSource[] yeahs;
	
	// Update is called once per frame
	void Update () {	
    	if (Input.GetKeyDown(KeyCode.Alpha1)) yeahs[1].Play();
		if (Input.GetKeyDown(KeyCode.Alpha2)) yeahs[2].Play();
		if (Input.GetKeyDown(KeyCode.Alpha3)) yeahs[3].Play();
		if (Input.GetKeyDown(KeyCode.Alpha4)) yeahs[4].Play();
		if (Input.GetKeyDown(KeyCode.Alpha5)) yeahs[5].Play();
		if (Input.GetKeyDown(KeyCode.Alpha6)) yeahs[6].Play();
		if (Input.GetKeyDown(KeyCode.Alpha7)) yeahs[7].Play();
		if (Input.GetKeyDown(KeyCode.Alpha8)) yeahs[8].Play();
		if (Input.GetKeyDown(KeyCode.Alpha9)) yeahs[9].Play();
		if (Input.GetKeyDown(KeyCode.Alpha0)) yeahs[0].Play();
		
	}
}
