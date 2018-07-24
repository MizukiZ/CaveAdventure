using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultipleWays : MonoBehaviour {

  GameObject route1,route2,route3,route4,route5,route6;

	// set in the component section as start point
  public int place;
	public int waySwitch;  // current route
  public float speed = 0.1f;
	bool firstMove = false;
	bool clockwise;
	private float lastSpeedUpTime;

	private AudioSource screamSE;	
  private AudioSource zombieSE;	

	
		void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			screamSE.PlayOneShot(screamSE.clip);
			Destroy (other.gameObject);

			Invoke("goLoseMenu", 1.5f);
			}
		}



	// Use this for initialization
	void Start () {

		// get object by name
		route1 = GameObject.Find( "route1" );
		route2 = GameObject.Find( "route2" );
		route3 = GameObject.Find( "route3" );
		route4 = GameObject.Find( "route4" );
		route5 = GameObject.Find( "route5" );
		route6 = GameObject.Find( "route6" );

		
		AudioSource[] audioSources = GetComponents<AudioSource>();
    screamSE = audioSources[0];
    zombieSE = audioSources[1];

		zombieSE.PlayOneShot(zombieSE.clip);
    
		// set initial direction
		clockwise = randomBoolean(0.5f);
    
		// initial speedup time
		lastSpeedUpTime = Time.time;

	}

	
	void FixedUpdate () {

	wayPointRun(findCorrespondingRoute(waySwitch));
  
	// every 20 sec this get called 
   if(Time.time - lastSpeedUpTime > 20f){
		 // set last update time
		 lastSpeedUpTime = Time.time;
  
   // 50% chance to speed up
     if(randomBoolean(0.5f)){
				speed += 0.025f;
			}
	 }
 }

 void goLoseMenu(){
	 SceneManager.LoadScene("Lose");
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
	 			//  70% chance to chage the route
				 if(randomBoolean(0.7f)){
      if(randomBoolean(0.5f)){
				// go to route3 place1
				chageWay(3,1);
				}
				else{
						// go to route5 place11
					chageWay(5,11);
				}
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
					else if(waySwitch == 2 && place == 7 && !firstMove){ 

      //  70% chance to chage the route
      if(randomBoolean(0.7f)){
				if(randomBoolean(0.5f)){
				chageWay(4,7);
				}else{
				chageWay(4,8);
				}
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}

				else if(waySwitch == 2 && place == 9 && !firstMove){ 

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
				else if(waySwitch == 3 && place == 2 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route5 place0
				chageWay(5,0);
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
				chageWay(2,9);
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
					else if(waySwitch == 4 && place == 8 && !firstMove){ 

      //  50% chance to chage the route
      if(randomBoolean(0.5f)){
				chageWay(2,7);
			}
			else{
					setNextPlace(route,clockwise);
				 }
				}
					else if(waySwitch == 5 && place == 0 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route3 place2
				chageWay(3,2);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
				else if(waySwitch == 5 && place == 7 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route6 place0
				chageWay(6,0);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
				else if(waySwitch == 5 && place == 9 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route2 place9
				chageWay(2,9);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
				else if(waySwitch == 5 && place == 11 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route3 place1
				chageWay(3,1);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
       else if(waySwitch == 6 && place == 0 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route5 place7
				chageWay(5,7);
				}
				else{
					setNextPlace(route,clockwise);
				}
				}
				else if(waySwitch == 6 && place == 6 && !firstMove){ 
	 			//  50% chance to chage the route
      if(randomBoolean(0.5f)){
				// go to route2 place10
				chageWay(2,10);
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
	 detectDirection(findCorrespondingRoute(waySwitch), findCorrespondingRoute(newWay), nextPlace);


	 waySwitch = newWay;
	 place = nextPlace;
	 firstMove = true;


	 clockwise = randomBoolean(0.5f);
 }

 void setNextPlace(GameObject route, bool clockwise){
  int nextPlace;
	 if(clockwise){
	 // when the place is last, goes back to the first (clockwise)]
	 nextPlace = (place + 1) % route.transform.childCount;
	 detectDirection(route, route, nextPlace);
	 place = nextPlace;
	 }
   else{
   // when the place is first, goes back to the last (anti-clockwise)
	 nextPlace = place == 0 ? route.transform.childCount - 1 : place -1;
	 detectDirection(route, route, nextPlace);
	 place = nextPlace;
	 firstMove = false;
	 }
 }

 void detectDirection(GameObject currentRoute, GameObject nextRoute, int nextPlace){
   Vector3 currentPosition = currentRoute.transform.GetChild(place).position;
	 Vector3 nextPosition = nextRoute.transform.GetChild(nextPlace).position;

	//  Debug.Log(currentPosition);
	//  Debug.Log(nextPosition);

	 if(currentPosition.x < nextPosition.x){
		//  moving towards right
		transform.rotation = Quaternion.Euler(0, 0, 0);
	 }
	 else if(currentPosition.x > nextPosition.x){
		 // moving towards left
		 transform.rotation = Quaternion.Euler(0f, 180f, 0f);
	 }
	 else if(currentPosition.y < nextPosition.y){
		 // moving towards up
		  transform.rotation = Quaternion.Euler(0f, 0f, 90f);
	 }
	 else if(currentPosition.y > nextPosition.y){
		 // moving towards down
		  transform.rotation = Quaternion.Euler(0f, 0f, 270f);
	 }

	 
    
 }

 GameObject findCorrespondingRoute(int routeNum){
   if(routeNum == 1) return route1;
	 if(routeNum == 2) return route2;
	 if(routeNum == 3) return route3;
	 if(routeNum == 4) return route4;
	 if(routeNum == 5) return route5;
	 if(routeNum == 6) return route6;

	 return null;
 }

}
