using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeVolume : MonoBehaviour {

    // Use this for initialization
    public Slider Volume;
    public AudioSource myMusic;
	
	// Update is called once per frame
	void Update () {
        myMusic.volume = Volume.value;

	}
}
