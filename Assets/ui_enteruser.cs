using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_enteruser : MonoBehaviour {

	public InputField UserNameField;
	public Button ButtonUserNameEntered;
	public void CheckInputField () {
		if (UserNameField.text == "") {
			ButtonUserNameEntered.interactable = false;
		} else {
			ButtonUserNameEntered.interactable = true;
		}
	}
	
	public void PlayOnline () {
		Debug.Log("Username " + UserNameField.text);
		this.gameObject.SetActive(false);
	}

	
}
