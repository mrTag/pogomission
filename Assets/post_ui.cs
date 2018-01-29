using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class post_ui : MonoBehaviour {

	public RectTransform Menu;
	public GameObject Manual;
	bool isOpen;
	bool finished = false;

	public RectTransform[] Buttons;
	public RectTransform Selector;
	private int _selection;

	public Text WishText;
	public Text WisherNameText;

	void Start () {
		Menu.anchoredPosition = new Vector2(0,-710);
		isOpen = false;
		if (WishMaster.Instance != null) {
			WisherNameText.text = "by: " + WishMaster.Instance.SelectedWishName;
			WishText.text = WishMaster.Instance.SelectedWishText;
		}
		Letter.Delivered += () => {
			finished = true;
			if (isOpen) ToggleMenu();
		};
	}

	void Update() {
		if (finished) return;
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Manual.activeSelf) {
				ToggleManual();
			} else {
				ToggleMenu();
			}
		}
		if (!Manual.activeSelf) {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				_selection--;
				if (_selection < 0) _selection = Buttons.Length - 1;
				Selector.localPosition = Buttons[_selection].localPosition;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				_selection++;
				if (_selection == Buttons.Length) _selection = 0;
				Selector.localPosition = Buttons[_selection].localPosition;
			}
			if (Input.GetKeyDown(KeyCode.Return)) {
				switch(_selection) {
					case 0: ToggleMenu(); break;
					case 1: ToggleManual(); break;
					case 2: GiveUp(); break;
				}
			}
		}
	}

	public void ToggleMenu() {
		if (isOpen) {
			Time.timeScale = 1f;
			isOpen = false;
			Menu.DOKill();
			Menu.DOAnchorPosY(-710,.5f).SetEase(Ease.OutBack).SetUpdate(true);
			
		} else {
			Time.timeScale = 0f;
			isOpen = true;
			Menu.DOKill();
			Menu.DOAnchorPosY(0,.5f).SetEase(Ease.OutBack).SetUpdate(true);
		}
	}

	public void ToggleManual() {
		Manual.SetActive(!Manual.activeSelf);
	}

	public void GiveUp() {
		SceneManager.LoadScene("menu");
	}
}
