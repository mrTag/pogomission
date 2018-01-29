using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ui_ending : MonoBehaviour {

	public Text WishText;
	public Text WishName;
	public GameObject Panel;

	void Start () {
		if (WishMaster.Instance != null) {
			WishText.text = WishMaster.Instance.SelectedWishText;
			WishName.text = "by: " + WishMaster.Instance.SelectedWishName;
		}
		Letter.Delivered += Show;
	}
	
	public void Show() {
		Invoke("ShowInternal", 2f);
	}

	private void ShowInternal() {
		Panel.SetActive(true);
	}
}
