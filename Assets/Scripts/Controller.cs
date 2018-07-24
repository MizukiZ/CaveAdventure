using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	private GameObject player;
	private Animator animator;
	private Player ps;
	GameObject swapOb;
	private Button swapButton;

	public GameObject pauseUI;

	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	bool attack = false;
	bool swap = false;

	bool paused = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find( "survivor" );
		
		if(player) {
		animator = player.GetComponent<Animator> ();
		ps = player.GetComponent<Player> ();
		}
    
		swapOb = GameObject.Find( "swap" );
		swapButton = swapOb.GetComponent<Button> ();
		swapButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(player){


	  if(ps.needToggle){
			swapButton.interactable = true;
		}else{
			swapButton.interactable = false;
		}
    
   
		if(left){
      ps.move("left");
		 player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			   animator.SetBool("Move",true);
		}

		if(right){
      ps.move("right");
		 	player.transform.rotation = Quaternion.Euler(0, 0, 0);
			 animator.SetBool("Move",true);
		}

		if(up){
      ps.move("up");
		  player.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			animator.SetBool("Move",true);
		}

		if(down){
      ps.move("down");
		 player.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
					 animator.SetBool("Move",true);
		}

		if(attack && animator.GetBool("Knife") && !ps.nowSwinging && ps.isStop()){
      ps.knifeAttack();
			attack = false;
		}

		if(attack && animator.GetBool("Gun") && ps.isStop()){
      ps.gunShoot();
			attack = false;
		}

		if(swap && ps.needToggle){
			ps.swapWeapon();
			swap = false;
		}

		}

	}

	public void PushDown(string dir){
		if(player){
		if(dir == "left") left = true;
		if(dir == "right") right = true;
		if(dir == "up") up = true;
		if(dir == "down") down = true;
		if(dir == "attack") attack = true;
		if(dir == "swap") swap = true;

  	if(dir == "pause") {
  
			if(!paused)	{
				// pause process
			
				Time.timeScale = 0f;
				paused = true;
				pauseUI.SetActive(true);
				}
				else{
				// unpause process
         Time.timeScale = 1f;
				 paused = false;
				 pauseUI.SetActive(false);
				}

		};
		}
	}
	
	public void PushUp(string dir){
		if(player){
    if(dir == "left") left = false;
		if(dir == "right") right = false;
		if(dir == "up") up = false;
		if(dir == "down") down = false;
		if(dir == "attack") attack = false;
		if(dir == "swap") swap = false;
     ps.move("stop");
		 animator.SetBool("Move",false);
		}
	}
}
