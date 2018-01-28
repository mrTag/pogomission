using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_enterwish : MonoBehaviour {

	public InputField WishField;
	public Button ButtonSendWish;
	public void CheckInputField () {
		if (WishField.text == "") {
			ButtonSendWish.interactable = false;
		} else {
			ButtonSendWish.interactable = true;
		}
	}
	
	public void PlayOnline () {
		Debug.Log("Wish " + WishField.text);
		this.gameObject.SetActive(false);
	}
}
