using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_enteruser : MonoBehaviour {

	public InputField UserNameField;
	public Button ButtonUserNameEntered;

	public System.Action OnPlayOnline = delegate {};
	public System.Action OnPlayOffline = delegate {};

	public void CheckInputField () {
		if (UserNameField.text == "") {
			ButtonUserNameEntered.interactable = false;
		} else {
			ButtonUserNameEntered.interactable = true;
		}
	}
	
	public void PlayOnline () {
		ButtonUserNameEntered.interactable = false;
		WishMaster.Instance.Login(() => {
			WishMaster.Instance.PlayerName = UserNameField.text;
			OnPlayOnline();
		},
		() => {
			Debug.Log("CONNECTION FAILED");
			ButtonUserNameEntered.interactable = true;
		});
	}

	public void PlayOffline () {
		OnPlayOffline();
	}	
}
