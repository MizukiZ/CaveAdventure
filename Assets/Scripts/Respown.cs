using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respown : MonoBehaviour {

	private float initialTime;
	public GameObject newEnemyOb;


	public int startRoute;
	public int startPlace;
	public Quaternion startDirection;
	



	// Use this for initialization
	void Start () {
	initialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		// after 15 sec this get called 
   if(Time.time - initialTime  > 15f){
     respown();
	 }
		
	}

		void respown(){
	  // create new enemy
		GameObject newEnemyO = Instantiate(newEnemyOb,transform.position,startDirection) as GameObject;
		
		// get script from enemy object
		MultipleWays enemySc = newEnemyO.GetComponent<MultipleWays>();

		// set start point 
    enemySc.waySwitch = startRoute;
		enemySc.place = startPlace;

    // destory respown place object
		Destroy(gameObject);

		}
}
