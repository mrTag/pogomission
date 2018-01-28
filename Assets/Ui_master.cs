using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_master : MonoBehaviour {

	public GameObject StartSceen;
	public ui_enteruser Enteruser;
	public ui_enterwish Enterwish;
	public ui_wishlist Wishlist;

	// Use this for initialization
	void Start () {
		Enteruser.OnPlayOnline += () => {
			Enteruser.gameObject.SetActive(false);
			Enterwish.gameObject.SetActive(true);
		};
		Enteruser.OnPlayOffline += () => {
			StartPlaying();
		};
		StartSceen.SetActive(true);
		StartSceen.GetComponentInChildren<Button>().onClick.AddListener(() => {
			StartSceen.SetActive(false);
			Enteruser.gameObject.SetActive(true);
		});
		Enteruser.OnPlayOnline += () => {
			Enteruser.gameObject.SetActive(false);
			Enterwish.gameObject.SetActive(true);
		};
		Enteruser.OnPlayOffline += () => {
			StartPlaying();
		};
		Enterwish.OnOK += () => {
			Enterwish.gameObject.SetActive(false);
			Wishlist.gameObject.SetActive(true);
		};
		Enterwish.OnWishMade  += (wishID) => {
			Enterwish.gameObject.SetActive(false);
			Wishlist.OwnWishID = wishID;
			Wishlist.gameObject.SetActive(true);
		};
		Wishlist.OnWishDeliver += () => {
			StartPlaying();
		};
	}
	
	public void StartPlaying() {
		SceneManager.LoadScene("game");
	}
}
