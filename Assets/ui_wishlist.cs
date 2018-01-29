using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_wishlist : MonoBehaviour {

	public Button Button_DeliverWish;
	public GameObject MyWishBar;
	public Transform MyWishPos;
	public entry_wishlist Prefab_EntryWishlist;
	public entry_wishlist Prefab_EntryMyWish;
	public RectTransform WishListTransform;

	public string OwnWishID;

	private entry_wishlist CurrentSelection = null;

	public System.Action OnWishDeliver;

	void Start () {
		Button_DeliverWish.interactable = false;
		WishMaster.Instance.GetWishes((wishlist) => {
			foreach(var wish in wishlist){
				entry_wishlist NewEntry;
                if(wish.WishID == OwnWishID){
					NewEntry = Instantiate(Prefab_EntryMyWish);
					NewEntry.gameObject.transform.SetParent(MyWishPos,false);
				} else {
					NewEntry = Instantiate(Prefab_EntryWishlist);
					NewEntry.gameObject.transform.SetParent(WishListTransform,false);
				}
				NewEntry.EntrySelected += EntrySelected;
				
				NewEntry.SetData(wish.WishID, wish.WishText, wish.WishingPlayer, wish.FullfillingPlayer);
			}
		},
		() => {
			Debug.Log("COULDN't GET WISHLIST");
		});
	}

	void EntrySelected(entry_wishlist pSelectedEntry) {
		if (CurrentSelection != null) {
			CurrentSelection.SetSelectedState(false);			
		}		
		CurrentSelection = pSelectedEntry;
		pSelectedEntry.SetSelectedState(true);

		Button_DeliverWish.interactable = true;
	}

	public void DeliverWish() {
		WishMaster.Instance.SelectedWishID = CurrentSelection.WishID;
		WishMaster.Instance.SelectedWishName = CurrentSelection.WishedBy;
		WishMaster.Instance.SelectedWishText = CurrentSelection.TextWish.text;
		OnWishDeliver();
	}
}
