using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleWays : MonoBehaviour {

  GameObject route1,route2,route3,route4;

	// set in the component section as start point
  public int place;
	public int waySwitch;  // current route
  public float speed = 0.1f;
	bool firstMove = false;
	bool clockwise;

	
		void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") Destroy (other.gameObject);
		}



	// Use this for initialization
	void Start () {
    
		// set initial direction
		clockwise = randomBoolean(0.5f);

		// get object by name
		route1 = GameObject.Find( "route1" );
		route2 = GameObject.Find( "route2" );
		route3 = GameObject.Find( "route3" );
		route4 = GameObject.Find( "route4" );
	}

	
	void FixedUpdate () {
	 if(waySwitch == 1) wayPointRun(route1);
	 if(waySwitch == 2) wayPointRun(route2);
	 if(waySwitch == 3) wayPointRun(route3);
	 if(waySwitch == 4) wayPointRun(route4);
 }


 void wayPointRun (GameObject route) {

 if (transform.position != route.transform.GetChild(place).position) {
	
        Vector2 p = Vector2.MoveTowards(transform.position,route.transform.GetChild(place).position,speed);

        GetComponent<Rigidbody2D>().MovePosition(p);
    }
      // set next one
    else {
　　　　// switch point and switch way
			if(waySwitch == 1 && place == 2 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route2 place0
				chageWay(2,0);
				}
				else{
					setNextPlace(route,clockwise);
			  	}
				}
				else if(waySwitch == 1 && place == 4 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route3 place1
				chageWay(3,1);
				}
				else{
					setNextPlace(route,clockwise);
			  	}
				}
			else if(waySwitch == 2 && place == 0 && !firstMove){ 

      //  70% chance to chage the route
      if(randomBoolean(0.7f)){

				if(randomBoolean(0.5f)){
      	// go to route1 place2
				chageWay(1,2);
				}
				else{
				// go to route3 place0
				chageWay(3,0);
				}
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}

				else if(waySwitch == 2 && place == 6 && !firstMove){ 

      //  50% chance to chage the route
      if(randomBoolean(0.5f)){
				chageWay(4,0);
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}

			else if(waySwitch == 3 && place == 1 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route1 place4
				chageWay(1,4);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
			else if(waySwitch == 3 && place == 0 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.7f)){
				if(randomBoolean(0.5f)){
           // go to route2 place0
			   	chageWay(2,0);
				}else{
					// go to route4 place6
          chageWay(4,6);
				 }
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
			else if(waySwitch == 4 && place == 0 && !firstMove){ 

      //  50% chance to chage the route
      if(randomBoolean(0.5f)){
				chageWay(2,6);
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}
				else if(waySwitch == 4 && place == 2 && !firstMove){ 

      //  50% chance to chage the route
      if(randomBoolean(0.5f)){
				chageWay(2,0);
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}
				else if(waySwitch == 4 && place == 6 && !firstMove){ 

      //  50% chance to chage the route
      if(randomBoolean(0.5f)){
				chageWay(3,0);
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}
			else{
				// go to next way point(after the last point, goes to the first point)
        	setNextPlace(route,clockwise);
			  	firstMove = false;
			}
			}

 }

 // probability e.g. 50% = 0.5, 30% = 0.3
 bool randomBoolean(float probability){
	 return Random.value < probability;
 }

 void chageWay(int newWay, int nextPlace){
	 waySwitch = newWay;
	 place = nextPlace;
	 firstMove = true;

	 clockwise = randomBoolean(0.5f);
 }

 void setNextPlace(GameObject route, bool clockwise){

	 if(clockwise){
	 // when the place is last, goes back to the first (clockwise)
	 place = (place + 1) % route.transform.childCount;
	 }
   else{
   // when the place is first, goes back to the last (anti-clockwise)
	 place = place == 0 ? route.transform.childCount - 1 : place -1;
	 firstMove = false;
	 }
 }

}
