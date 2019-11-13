using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// game manager class
public class GameManager : MonoBehaviour
{
    // prefabs that represent the grenades
    public GameObject leftGrenade;
    public GameObject rightGrenade;

    // prefabs that represent the grenades when
    // falling out of the sky
    public GameObject leftGrenadeSky;
    public GameObject rightGrenadeSky;

    // prefabs that represent the two facing
    // planes 
    public GameObject planeRight;
    public GameObject planeLeft;

    // bool for whether the grenade is dropped
    public bool dropped = false;

    // bools to keep track which side of the game the
    // grenade is on
    public bool onRight = false;
    public bool onLeft = false;

    // game object that holds the current grenade 
    // in use
    private GameObject currentGrenade;
    // game object that holds the current plane
    // in use
    private GameObject currentPlane;

    // reference to the timer
    private Timer timer;

    // bools that keep track of which direction the plane
    // is facing
    public bool planeFaceRight = true;
    public bool planeFaceLeft = false;

    // string tha holds the winner
    public static string winner;

    // the waitime between when a grenade spawns
    public float waitTime;

    private AudioSource audioSource; //reference to audio source on the score object
    public AudioClip fallingGrenade; //sound used for when plane shows up

    private void Start()
    {
        // get audio source
        audioSource = GetComponent<AudioSource>();

        // get a ref to the timer
        timer = GameObject.Find("Timer").GetComponent<Timer>();


        // send plane to drop grenade
        currentPlane = Instantiate(planeRight);


    }

    private void Update()
    {
        // determine which plane to destroy when it goes offscreen
        if(currentPlane != null && currentPlane.transform.position.x >= 11.54f && planeFaceRight==true)
        {
            Destroy(currentPlane);
        }
        else if (currentPlane != null && currentPlane.transform.position.x <= -11.33f && planeFaceLeft==true)
        {
            Destroy(currentPlane);

        }
    }

    // function ends the game and sends the winner
    // to the end screen
    public void EndGame()
    {

        if (onRight == true)
        {
            winner = "Left Side Wins!";
        }
        else
        {
            winner = "Right Side Wins!";
        }
        SceneManager.LoadScene("End Screen");
    }

    // spawns right moving plane 
    public void SpawnRightPlane()
    {
        currentPlane = Instantiate(planeRight);
        planeFaceRight = true;
        planeFaceLeft = false;
    }

    // spawns left moving plane
    public void SpawnLeftPlane()
    {
        currentPlane = Instantiate(planeLeft);
        planeFaceRight = false;
        planeFaceLeft = true;
    }

    // drop grenade on left side of game
    public void DropGrenadeLeft()
    {
        // play sound effect
        audioSource.PlayOneShot(fallingGrenade);
        currentGrenade = Instantiate(leftGrenadeSky);
        dropped = true;
        timer.timerStart = true;
    }

    // drop grenade on the right side of the game
    public void DropGrenadeRight()
    {
        // play sound effect
        audioSource.PlayOneShot(fallingGrenade);
        currentGrenade = Instantiate(rightGrenadeSky);
        dropped = true;
        timer.timerStart = true;
    }
    
    // destroy grenade on left side of game
    public void DestroyLeftGrenade()
    {
        // destroy the current ball in the court
        Destroy(currentGrenade);
        Invoke("PlaceGrenadeLeft", waitTime);
    }


    // destroy grenade on right side of game
    public void DestroyRightGrenade()
    {
        // destroy the current ball in the court
        Destroy(currentGrenade);
        Invoke("PlaceGrenadeRight", waitTime);
    }

    // place grenade on right side of game
    private void PlaceGrenadeRight()
    {
        currentGrenade = Instantiate(rightGrenade);
    }

    // place grenade on left side of game
    private void PlaceGrenadeLeft()
    {
        currentGrenade = Instantiate(leftGrenade);
    }

}
