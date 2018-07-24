using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
　
  
　private GameObject muzzle;
　private GameObject muzzleFlashP;
  private GameObject knifeSwing0,knifeSwing1,knifeSwing2,knifeSwing3;
  private Animator animator;

	public float speed = 5;
	public GameObject bulletOb;
	public GameObject flash;
	public GameObject swing;

	private bool nowSwinging = false;


		void OnTriggerEnter2D(Collider2D other) {
	      if(other.gameObject.tag == "gun"){
				 animator.SetBool("Gun",true);
				}
				else if(other.gameObject.tag == "knife"){
					animator.SetBool("Knife",true);
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
		
	}
	
	// Update is called once per frame
	void Update () {


		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2 (x,y).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * speed;

      if (Input.GetKeyDown(KeyCode.F) && animator.GetBool("Knife") && !nowSwinging && isStop()){

        animator.SetTrigger("KnifeAttack");
　　　　　Invoke("swingC",0.3f);
        Invoke("resetSwing",0.7f);

         nowSwinging = true;
			}

	 			if (Input.GetKeyDown(KeyCode.F) && animator.GetBool("Gun")  && isStop()){
		 animator.SetTrigger("Shoot");
            
    // create bullet object
		GameObject bullet = GameObject.Instantiate(bulletOb) as GameObject;
	  GameObject flashT = Instantiate(flash,muzzleFlashP.transform.position,muzzleFlashP.transform.rotation) as GameObject;

    bullet.transform.position = muzzle.transform.position;
		bullet.GetComponent<Rigidbody2D>().velocity = muzzle.transform.right * 10;

		Destroy(flashT, 0.3f);
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
	
	bool isStop(){
    return GetComponent<Rigidbody2D>().velocity.sqrMagnitude < .01;
	}
}
