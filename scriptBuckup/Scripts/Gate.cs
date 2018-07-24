using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
	public int needAmount = 5;
	private Animator animator;
　GameObject coinObj;
  Item i;

		void OnCollisionEnter2D() {
		if(animator.GetBool("open")){

			// Clear function here
			Debug.Log("Clear!!");
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
		if(i.getCoinCount() >= needAmount){
    animator.SetTrigger("open");
	}
	}
}
