using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class entry_wishlist : MonoBehaviour, IPointerClickHandler {

	public Image Img_Env_Closed;
	public Image Img_Env_Open;
	public Image Img_Entry;
	public Image[] Panels;
	public Text TextWish;
	public Text TextWisher;
	public Text TextDeliverer;
	public Color ColorNormal;
	public Color ColorSelected;

	[Header("Panel Colors")]
	public Color PanelColorUnfulfilled;
	public Color PanelColorFulfilled;
	public Color PanelColorUnfulfilled_s;
	public Color PanelColorFulfilled_s;


	private string wishID;
	public string WishID {get{return wishID;}}
	bool pIsFulfilled;

	public event System.Action <entry_wishlist> EntrySelected = delegate {};

	public void SetData(string pWishID, string pWish, string pWisher, string pFulfiller = "") {
		wishID = pWishID;
		TextWish.text = pWish;
		TextWisher.text = "wished by: " + pWisher;
		if (pFulfiller == "") {
			Img_Env_Closed.gameObject.SetActive(true);
			Img_Env_Open.gameObject.SetActive(false);
			TextDeliverer.text = "not delivered, yet";
		} else {
			Img_Env_Closed.gameObject.SetActive(false);
			Img_Env_Open.gameObject.SetActive(true);
			TextDeliverer.text = "delivered by: " + pFulfiller;
		}
	}

	public void SetSelectedState(bool pIsSelected) {
		Img_Entry.color = pIsSelected ? ColorSelected : ColorNormal;
		for (int i = 0; i < Panels.Length; ++i) {
			Panels[i].color = pIsSelected ?
				(pIsFulfilled ? PanelColorFulfilled_s : PanelColorUnfulfilled) :
				(pIsFulfilled ? PanelColorFulfilled : PanelColorUnfulfilled);
		}
	}

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
        EntrySelected(this);
    }
}
