using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {
   

    // Use this for initialization
    private void Awake()
    {
       
    }

    // Update is called once per frame
    public void ToggleSound() {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);

        }
        else {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}
