using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour {

	private Animator animator;
　GameObject coinObj;
  Item i;
  public Text coinText;
	private bool isOpen = false;


	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			
		  if(!isOpen){
    animator.SetTrigger("Open");
		i.setCoinCount(10);
    coinText.text = "Coin: " + i.getCoinCount();
		isOpen = true;
		}
		}
		
    }

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		coinObj = GameObject.Find("Coin");
		i = coinObj.GetComponent<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
