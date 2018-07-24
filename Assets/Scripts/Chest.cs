using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour {

	private Animator animator;
	private AudioSource coinsSE;
　GameObject coinObj;
  Item i;
  public Text coinText;
	public int amountOfCoins;
	


	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player" && !animator.GetBool("Open")){

    coinsSE.PlayOneShot(coinsSE.clip);
    animator.SetBool("Open",true);
		i.setCoinCount(amountOfCoins);
    coinText.text = "Coin: " + i.getCoinCount();

		}
		
    }

	// Use this for initialization
	void Start () {
		coinsSE = GetComponent<AudioSource>();	
		animator = GetComponent<Animator> ();
		coinObj = GameObject.Find("Coin");
		i = coinObj.GetComponent<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
