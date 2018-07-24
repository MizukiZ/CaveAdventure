using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

	public GameObject explosion;

		void OnTriggerEnter2D(Collider2D other) {
	      if(other.gameObject.tag == "enemy") {
					
					Destroy(other.gameObject);

				// create explosion 
        GameObject explosionO = Instantiate(explosion,other.gameObject.transform.position,other.gameObject.transform.rotation) as GameObject;

				// after 0.6s it destroys explosion object
        Destroy(explosionO, 0.6f);
					
					};
				
		}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
