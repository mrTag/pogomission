using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_wishlist : MonoBehaviour {

	public Button Button_DeliverWish;
	public GameObject MyWishBar;
	public Transform MyWishPos;
	public entry_wishlist Prefab_EntryWishlist;
	public RectTransform WishListTransform;

	private entry_wishlist CurrentSelection = null;

	void Start () {
		Button_DeliverWish.interactable = false;
		entry_wishlist NewEntry = Instantiate(Prefab_EntryWishlist);
		NewEntry.EntrySelected += EntrySelected;
		NewEntry.gameObject.transform.SetParent(MyWishPos,false);
		NewEntry.SetData("fljhsldfkjgghl","I want have 8 little kitties", "Harry");
	}

	void EntrySelected(entry_wishlist pSelectedEntry) {
		if (CurrentSelection != null) {
			CurrentSelection.SetSelectedState(false);			
		}		
		CurrentSelection = pSelectedEntry;
		pSelectedEntry.SetSelectedState(true);

		Button_DeliverWish.interactable = true;
	}

	
}
