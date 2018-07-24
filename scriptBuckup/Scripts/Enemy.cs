using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

 private float stayTime;
 public float longestStay = 4f;
 private float lastChange;
 public float speed = 3;
 private Vector2 movementDirection;
 private Vector2 movementPerSecond;
 
 int[] ar = new int[2] {-1,1};
 int xDir;
 int yDir;
 

 	void OnCollisionEnter2D(Collision2D coll) {
		 if (coll.gameObject.tag == "maze"){
	        calcuateNewMovementVector("random");
			}
    }

		void OnCollisionExit2D(Collision2D coll) {
		   Debug.Log("exit");
    }


	// Use this for initialization
	void Start () {
		lastChange = 0f;
		xDir = 0;
		// latestDirectionChangeTime = 0f;
     calcuateNewMovementVector("random");
			// latestDirectionChangeTime = 0f;
	}

	void calcuateNewMovementVector(string order){
  

	  if (order == "random"){
		 //  choose xDir
		 if(xDir == 0){
			 xDir = ar[Random.Range(0,2)];
			  yDir = 0;
		 }else{
       xDir = 0;
			yDir = ar[Random.Range(0,2)];
		 }}
		else if(order == "right"){
     xDir = 1;
		 yDir = 0;
		}
		else if(order == "left"){
     xDir = -1;
		 yDir = 0;
		}
		else if(order == "up"){
     xDir = 0;
		 yDir = 1;
		}
		else if(order == "down"){
     xDir = 0;
		 yDir = -1;
		}

     movementDirection = new Vector2(xDir,yDir).normalized;
     movementPerSecond = movementDirection * speed;

		 lastChange = Time.time;
 }
	

	void Update () {
   // when the enemy got stack
   if(Time.time - lastChange > longestStay){

		 if(xDir==1 && yDir==0) calcuateNewMovementVector("left");
		 else if(xDir==-1 && yDir==0) calcuateNewMovementVector("right");
		 else if(xDir==0 && yDir==-1) calcuateNewMovementVector("up");
		 else if(xDir==0 && yDir==1) calcuateNewMovementVector("down");
	 }

	//move enemy: 
     transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
     transform.position.y + (movementPerSecond.y * Time.deltaTime));
	}
}