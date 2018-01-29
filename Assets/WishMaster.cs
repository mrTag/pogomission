using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wish {
	public string WishText;
	public string WishingPlayer;
	public string FullfillingPlayer;
	public string WishID;
}

public class WishMaster : MonoBehaviour {

	public static WishMaster Instance {
		get { return _instance; }
	}
	private static WishMaster _instance;

	public string PlayerName;
	public string SelectedWishID;
	public string SelectedWishName = "";
	public string SelectedWishText = "";
	void Awake()
	{
		if (_instance == null) {
            _instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
	}

/* 
	IEnumerator Start(){
		Debug.Log("testing coroutine started! waiting 5 sec.");
		yield return new WaitForSeconds(5);
		Debug.Log("Login");
		Login(() => Debug.Log("successcallback"), () => Debug.Log("errorcallback"));
		Debug.Log("waiting 5 sec.");
		yield return new WaitForSeconds(5);
		string savedWishID = "";
		MakeAWish("yet another wish from unity coroutine", "unity player", (wishID) => savedWishID = wishID, () => Debug.Log("errorcallback"));
		Debug.Log("waiting 5 sec.");
		yield return new WaitForSeconds(5);
		Debug.Log("returned wishID: " + savedWishID);
		FullfillWish(savedWishID, "another player");
		Debug.Log("waiting 5 sec.");
        yield return new WaitForSeconds(5);
		GetWishes((wishList) => {
			foreach(var wish in wishList) {
				Debug.Log(JsonUtility.ToJson(wish));
			}
		}, () => Debug.Log("errorcallback"));
    } */

	public void Login(System.Action successCallback, System.Action errorCallback) {
		new GameSparks.Api.Requests.DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Gamesparks: Device Authenticated...");
				successCallback();
            }
            else
            {
                Debug.Log("Gamesparks: Error Authenticating Device...");
				errorCallback();
            }
        });
	}

	public void MakeAWish(string wishText, string playername, System.Action<string> successCallback, System.Action errorCallback) {
		new GameSparks.Api.Requests.LogEventRequest().SetEventKey("UPLOAD_WISH").
			SetEventAttribute("WISH_TEXT", wishText).
			SetEventAttribute("PLAYER_NAME", playername).
			Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Wish saved to GameSparks successfully...");
				successCallback(response.ScriptData.GetString("wishID"));
            }
            else
            {
                Debug.Log("Error Saving Player Data...");
				errorCallback();
            }
        });
	}

	public void GetWishes(System.Action<List<Wish>> successCallback, System.Action errorCallback){
		new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_WISHES").
            Send((response) =>
        {
            if (!response.HasErrors)
            {
				var gsdataWishlist = response.ScriptData.GetGSDataList("wishes");
				var wishList = new List<Wish>();
                foreach(var wishData in gsdataWishlist){
					wishList.Add(new Wish {
						WishText = wishData.GetString("wish_text"),
						WishingPlayer = wishData.GetString("wishing_player"),
						FullfillingPlayer = wishData.GetString("fullfill_player"),
						WishID = wishData.GetGSData("_id").GetString("$oid")
					});
				}
				successCallback(wishList);
            }
            else
            {
                Debug.Log("Error getting wishes from gamesparks...");
                errorCallback();
            }
        });
	}

	public void FullfillWish(string wishID, string playername) {
		new GameSparks.Api.Requests.LogEventRequest().SetEventKey("FULLFILL_WISH").
            SetEventAttribute("PLAYER_NAME", playername).
			SetEventAttribute("WISH_ID", wishID).
            Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Wish fullfill to GameSparks successfully...");
            }
            else
            {
                Debug.Log("Error fullfilling wish to gamesparks...");
            }
        });
	}
}
