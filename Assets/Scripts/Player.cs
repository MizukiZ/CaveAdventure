using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
　
  public int bulletSpeed = 20;
	public int bulletLimit = 3;

	private AudioSource shootSE;
	private AudioSource swingSE;
	private AudioSource coinSE;	
	
	public Image knifeSlot;
	public Image gunSlot;
	public Image bulletSlot1;
	public Image bulletSlot2;
	public Image bulletSlot3;
		

　private GameObject muzzle;
　private GameObject muzzleFlashP;
  private GameObject knifeSwing0,knifeSwing1,knifeSwing2,knifeSwing3;
  private Animator animator;

	public float playerSpeed = 5;
	public GameObject bulletOb;
	public GameObject flash;
	public GameObject swing;

	public bool nowSwinging = false;
	public bool needToggle = false;
	

		void OnTriggerEnter2D(Collider2D other) {
	      if(other.gameObject.tag == "gun"){
				 if(animator.GetBool("Knife")) {
					 animator.SetBool("Knife",false);
					 changeOpacity(0.5f,knifeSlot);
					 needToggle = true;
					 }

					 changeOpacity(1f,gunSlot);
					 changeOpacity(1f,bulletSlot1);
					 changeOpacity(1f,bulletSlot2);
					 changeOpacity(1f,bulletSlot3);					 

				 animator.SetBool("Gun",true);
				}
				else if(other.gameObject.tag == "knife"){
					 if(animator.GetBool("Gun")){ 
						 animator.SetBool("Gun",false);
						 changeOpacity(0.5f,gunSlot);
						 needToggle = true;
						 }

					 changeOpacity(1f,knifeSlot);

					animator.SetBool("Knife",true);
				}
				else if(other.gameObject.tag == "coins"){
						coinSE.PlayOneShot(coinSE.clip);
				}
		}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		muzzle = GameObject.Find("muzzle");
		muzzleFlashP = GameObject.Find("muzzleFlashPoint");
		knifeSwing0 = GameObject.Find("knifeSwing0");
		knifeSwing1 = GameObject.Find("knifeSwing1");
		knifeSwing2 = GameObject.Find("knifeSwing2");
		knifeSwing3 = GameObject.Find("knifeSwing3");
		
	  AudioSource[] audioSources = GetComponents<AudioSource>();
    shootSE = audioSources[0];
    swingSE = audioSources[1];
		coinSE = audioSources[2];	
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetKey(KeyCode.UpArrow)){
       move("up");
					 }
	  else if (Input.GetKey(KeyCode.DownArrow)){
       move("down");
					 }
		else if (Input.GetKey(KeyCode.LeftArrow)){
　　　　move("left");
					 }
		else if (Input.GetKey(KeyCode.RightArrow)){
		   move("right");
					 }
		else if (Input.GetKeyUp(KeyCode.UpArrow)){
			 move("stop");
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow)){
		 	move("stop");
		}
		else if (Input.GetKeyUp(KeyCode.LeftArrow)){
			 move("stop");
		}
		else if (Input.GetKeyUp(KeyCode.RightArrow)){
			move("stop");
		}
		
      if (Input.GetKeyDown(KeyCode.F) && animator.GetBool("Knife") && !nowSwinging && isStop()){
        knifeAttack();
			}

	 			if (Input.GetKeyDown(KeyCode.F) && animator.GetBool("Gun")  && isStop()){
		      gunShoot();
					 }

  // toggle weapon when needed
			if(Input.GetKeyDown(KeyCode.R) && needToggle){
		     swapWeapon();
			}	

    // when player used up the bullets 
			if(bulletLimit == 0){
				animator.SetBool("Gun", false);
				if(needToggle){ 
					// switch to knife
					changeOpacity(1f,knifeSlot);
					animator.SetBool("Knife", true);
					}
				needToggle = false;
				changeOpacity(0.5f,gunSlot);
			}
      
			if (animator.GetBool("Gun")){ 
			bulletSlotMnage(bulletLimit);
			}else if(!animator.GetBool("Gun")){
				bulletSlotDisable();
			}
	}

	void swingC(){
		GameObject swing0 = Instantiate(swing,knifeSwing0.transform.position,knifeSwing0.transform.rotation) as GameObject;
		GameObject swing1 = Instantiate(swing,knifeSwing1.transform.position,knifeSwing1.transform.rotation) as GameObject;
		GameObject swing2 = Instantiate(swing,knifeSwing2.transform.position,knifeSwing2.transform.rotation) as GameObject;
		GameObject swing3 = Instantiate(swing,knifeSwing3.transform.position,knifeSwing3.transform.rotation) as GameObject;
		Destroy(swing0, 0.1f);
		Destroy(swing1, 0.1f);
		Destroy(swing2, 0.1f);
		Destroy(swing3, 0.1f);
	}

	void resetSwing(){
		nowSwinging = false;
	}
	
	public bool isStop(){
    return GetComponent<Rigidbody2D>().velocity.sqrMagnitude < .01;
	}

	void changeOpacity(float opacity, Image imageOb){
		Color newColor = imageOb.color;
           newColor.a = opacity;
					 imageOb.color = newColor;
	}

	void bulletSlotMnage(int bullets){

	  if(bullets == 3){
			changeOpacity(1f,bulletSlot3);
			changeOpacity(1f,bulletSlot2);
			changeOpacity(1f,bulletSlot1);
			}
    else if(bullets == 2){
			changeOpacity(0.5f,bulletSlot3);
			changeOpacity(1f,bulletSlot2);
			changeOpacity(1f,bulletSlot1);
			}
		else if(bullets == 1){
			changeOpacity(0.5f,bulletSlot3);
			changeOpacity(0.5f,bulletSlot2);
			changeOpacity(1f,bulletSlot1);
			}
		else if(bullets == 0) bulletSlotDisable();
	}

	void bulletSlotDisable(){
		changeOpacity(0.5f,bulletSlot1);
		changeOpacity(0.5f,bulletSlot2);
    changeOpacity(0.5f,bulletSlot3);
	}

	public void move(string face){
		float dir = 0f;
    if(face == "stop"){
      Vector2 direction = new Vector2 (0,0).normalized;
		 GetComponent<Rigidbody2D>().velocity = direction * playerSpeed;
		}

    if(face == "up"|| face == "right") dir = 1f;
    if(face == "down"|| face == "left") dir = -1f;

		if(face == "up" || face == "down"){
			Vector2 direction = new Vector2 (0,dir).normalized;
		 GetComponent<Rigidbody2D>().velocity = direction * playerSpeed;
		}

		if(face == "left" || face == "right"){
			Vector2 direction = new Vector2 (dir,0).normalized;
		 GetComponent<Rigidbody2D>().velocity = direction * playerSpeed;
		}
	}

	public void knifeAttack(){
		swingSE.PlayOneShot(swingSE.clip);
        animator.SetTrigger("KnifeAttack");
　　　　　Invoke("swingC",0.3f);
        Invoke("resetSwing",0.7f);
				 nowSwinging = true;
	}

	public void gunShoot(){
    animator.SetTrigger("Shoot");
       shootSE.PlayOneShot(shootSE.clip);
			 bulletLimit -=1;
            
    // create bullet object
		GameObject bullet = GameObject.Instantiate(bulletOb) as GameObject;
	  GameObject flashT = Instantiate(flash,muzzleFlashP.transform.position,muzzleFlashP.transform.rotation) as GameObject;

    bullet.transform.position = muzzle.transform.position;
		bullet.GetComponent<Rigidbody2D>().velocity = muzzle.transform.right * bulletSpeed;

		Destroy(flashT, 0.3f);
	}

  public void swapWeapon(){
   	if(animator.GetBool("Knife")) {
				// knife to gun
				animator.SetBool("Knife", false);
				animator.SetBool("Gun", true);
				changeOpacity(1f,gunSlot);
				changeOpacity(0.5f,knifeSlot);					
				}
			else if(!animator.GetBool("Knife")){
       // gun to knife
				 animator.SetBool("Knife", true);
				 animator.SetBool("Gun", false);
				 changeOpacity(1f,knifeSlot);
				changeOpacity(0.5f,gunSlot);		
				 }
	}
  
}
