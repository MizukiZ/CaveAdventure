using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour {

private AudioSource BGM;
	// Use this for initialization
	void Start () {
		BGM = GetComponent<AudioSource>();
		BGM.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
