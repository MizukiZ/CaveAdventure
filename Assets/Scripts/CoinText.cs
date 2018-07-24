using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour {
	
 public Text coinText;

  public void coinCount(){
		coinText.text = "Coin: " + Item.coinCount;
	}

	// Use this for initialization
	void Start () {
		coinText.text = "Coin: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
