using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseSoundScript : MonoBehaviour {
    
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

	// Use this for initialization
	void Start () {
        UpdateIcon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PauseMusic() {
        ToggleSound();
        UpdateIcon();
    }
    void UpdateIcon() {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;

        }
        else {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }

		void ToggleSound() {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);

        }
        else {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}
