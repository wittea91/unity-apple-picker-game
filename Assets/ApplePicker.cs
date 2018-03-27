using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject 	basketPrefab;
	public int numBaskets = 3;
	public float 	basketBottomY = -14f;
	public float 	basketSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject> (basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add(tBasketGO);
		}
	}

	public void AppleDestroyed(){
		// Getting all the Apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}

		// Destroy one of the baskets
		int basketIndex = basketList.Count - 1;
		// Get the Basket Game Object we need to destroy
		GameObject tBasketGO = basketList[basketIndex];
		// Remove this basket from the List
		basketList.RemoveAt (basketIndex);
		// Destroy It
		Destroy (tBasketGO);

		// If we ran out of baskets - reset the game
		if (basketList.Count == 0){
			SceneManager.LoadScene("_Scene_0");
		}
	}



}
