using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            audioSource.mute = !audioSource.mute;
    }
}