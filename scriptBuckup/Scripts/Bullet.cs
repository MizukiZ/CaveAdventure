using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int speed = 10;

    void OnTriggerEnter2D(Collider2D other) {
	    if(other.gameObject.tag == "maze") Destroy(gameObject);
        if(other.gameObject.tag == "enemy") Destroy(other.gameObject);
    }

    void Start ()
    {
    // GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }

	
	// Update is called once per frame
	void Update () {

}
}
