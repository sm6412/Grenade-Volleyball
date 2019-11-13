using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinningSide : MonoBehaviour
{
    // text that represents the winning side
    public Text winningSide;

    private AudioSource audioSource; //reference to audio source on the score object
    public AudioClip explosion; // explosion sound


    // Start is called before the first frame update
    void Start()
    {
        // get audio source
        audioSource = GetComponent<AudioSource>();

        // play sound effect

        audioSource.PlayOneShot(explosion);
        // set the text equal to the winning side  
        winningSide.text = GameManager.winner;
    }
}
