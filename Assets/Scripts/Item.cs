using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour {

 public static int coinCount;
 CoinText coinT;

	void OnTriggerEnter2D(Collider2D other) {
	
  // function for coins
		if(gameObject.tag == "coins" && other.gameObject.tag == "Player"){
				coinCount++;
      // call coinCount function from coinT
				coinT.coinCount();
		}
		
    if(other.gameObject.tag == "Player") Destroy (gameObject);
    }

		// static variable getter
		public int getCoinCount(){
			return coinCount;
		}


		// static variable setter
     public void setCoinCount(int x){
			 coinCount += x;
		 }

	// Use this for initialization
	void Start () {

		coinCount = 0;
		// get coinText script
		if( gameObject.tag == "coins") {
		coinT = GetComponent<CoinText>();
	}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
