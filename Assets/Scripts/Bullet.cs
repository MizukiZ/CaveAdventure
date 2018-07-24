using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public GameObject explosion;
    public GameObject respownPlace;


    void OnTriggerEnter2D(Collider2D other) {
	    if(other.gameObject.tag == "maze") Destroy(gameObject);

        if(other.gameObject.tag == "enemy"){ 
            //  kill enemy script here
        Destroy(other.gameObject);

        // create explosion 
        GameObject explosionO = Instantiate(explosion,other.gameObject.transform.position,other.gameObject.transform.rotation) as GameObject;

        // create respown place at where enemy was killed
        GameObject respownPlaceO = Instantiate(respownPlace,
        other.gameObject.transform.position,Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
       
       // get each script form objects
        MultipleWays enemySc = other.gameObject.GetComponent<MultipleWays>();
        Respown respownSc = respownPlaceO.GetComponent<Respown>();

        // set enemy's killed position for the respown enemy's start point
        respownSc.startRoute = enemySc.waySwitch;
        respownSc.startPlace = enemySc.place;
        respownSc.startDirection = other.gameObject.transform.rotation;

       
       // after 0.6s it destroys explosion object
        Destroy(explosionO, 0.6f);
        }
    }

    void Start ()
    {
    }

	
	// Update is called once per frame
	void Update () {

}
}
