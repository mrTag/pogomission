using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_enterwish : MonoBehaviour {

	public InputField WishField;
	public Button ButtonSendWish;

	public System.Action<string> OnWishMade;
	public System.Action OnOK;

	public void CheckInputField () {
		if (WishField.text == "") {
			ButtonSendWish.interactable = false;
		} else {
			ButtonSendWish.interactable = true;
		}
	}
	
	public void WishButton () {
		ButtonSendWish.interactable = false;
		WishMaster.Instance.MakeAWish(
			WishField.text,
			WishMaster.Instance.PlayerName,
			(wishID) => {
				this.gameObject.SetActive(false);
				OnWishMade(wishID);
			},
			() => {
				Debug.Log("MAKE WISH FAILED");
				ButtonSendWish.interactable = true;
			}
		);
	}

	public void ImOKButton() {
		OnOK();
	}
}
