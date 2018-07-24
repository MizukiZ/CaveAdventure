using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {
  private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
       transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			  animator.SetBool("Move",true);
					 }
	  else if (Input.GetKey(KeyCode.DownArrow)){
          transform.rotation = Quaternion.Euler(0f, 0f, 270f);
					 animator.SetBool("Move",true);
					 }
		else if (Input.GetKey(KeyCode.LeftArrow)){
　　　　transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			   animator.SetBool("Move",true);
					 }
		else if (Input.GetKey(KeyCode.RightArrow)){
			transform.rotation = Quaternion.Euler(0, 0, 0);
			 animator.SetBool("Move",true);
					 }
		else if (Input.GetKeyUp(KeyCode.UpArrow)){
			 animator.SetBool("Move",false);
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow)){
			 animator.SetBool("Move",false);
		}
		else if (Input.GetKeyUp(KeyCode.LeftArrow)){
			 animator.SetBool("Move",false);
		}
		else if (Input.GetKeyUp(KeyCode.RightArrow)){
			 animator.SetBool("Move",false);
		}

	}

}
