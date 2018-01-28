using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class entry_wishlist : MonoBehaviour, IPointerClickHandler {

	public Image Img_Env_Closed;
	public Image Img_Env_Open;
	public Image Img_Entry;
	public Text TextWish;
	public Color ColorNormal;
	public Color ColorSelected;

	private string wishID;
	public string WishID {get{return wishID;}}
	bool pIsFulfilled;

	public event System.Action <entry_wishlist> EntrySelected = delegate {};

	public void SetData(string pWishID, string pWish, string pWisher, string pFulfiller = "") {
		wishID = pWishID;
		TextWish.text = pWish;
		if (pFulfiller == "") {
			Img_Env_Closed.gameObject.SetActive(true);
			Img_Env_Open.gameObject.SetActive(false);
		} else {
			Img_Env_Closed.gameObject.SetActive(false);
			Img_Env_Open.gameObject.SetActive(true);
		}
	}

	public void SetSelectedState(bool pIsSelected) {
		if (pIsSelected) {
			Img_Entry.color = ColorSelected;
		} else {
			Img_Entry.color = ColorNormal;
		}
	}

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        EntrySelected(this);
    }
}
