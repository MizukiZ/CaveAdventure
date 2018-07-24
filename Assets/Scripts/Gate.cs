using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour {
  
	private AudioSource openSE;	

	public int needAmount = 5;
	private Animator animator;
　GameObject coinObj;
  Item i;

	private bool isOpend = false;

		void OnCollisionEnter2D() {
		if(animator.GetBool("open")){
			// Clear function here
		SceneManager.LoadScene("Won");
		}
		
    }

	

	// Use this for initialization
	void Start () {
		openSE = GetComponent<AudioSource>();

		animator = GetComponent<Animator> ();
		coinObj = GameObject.Find("Coin");
		i = coinObj.GetComponent<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		if(i.getCoinCount() >= needAmount){
		if(!isOpend) openSE.PlayOneShot(openSE.clip);
    animator.SetTrigger("open");
		isOpend = true;
	}
	}
}
