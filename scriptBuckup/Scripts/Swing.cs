using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

		void OnTriggerEnter2D(Collider2D other) {
	      if(other.gameObject.tag == "enemy") Destroy(other.gameObject);
				
		}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
