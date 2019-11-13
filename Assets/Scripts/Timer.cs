using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // text that displays the timer
    public Text timerText;
    // string to hold the timer val
    static public string timeStr;
    // float to keep track of time
    public float time = 0;
    
    // bool to determine whether the timer
    // has started
    public bool timerStart = false;

    // ref to gm
    private GameManager gm;

    // keeps track of whether planes have spawned
    private bool planeHasSpawned1 = false;
    private bool planeHasSpawned2 = false;

    // bool that holds whether the game has ended or not
    public bool endGame = false;

    
    private void Start()
    {
        // ref the gm
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (timerStart==true && endGame == false)
        {
            // decrement time
            time -= Time.deltaTime;

            // determine whether to spawn a plane or not
            if(Mathf.RoundToInt(time) == 40 && planeHasSpawned1 == false)
            {
                float random = Random.Range(0, 2);
                if (random == 0)
                {
                    gm.SpawnRightPlane();
                }
                else
                {
                    gm.SpawnLeftPlane();
                }
                planeHasSpawned1 = true;

            }
            else if (Mathf.RoundToInt(time) == 20 && planeHasSpawned2 == false)
            {
                float random = Random.Range(0, 2);
                if (random == 0)
                {
                    gm.SpawnRightPlane();
                }
                else
                {
                    gm.SpawnLeftPlane();
                }
                planeHasSpawned2 = true;

            }

            timerText.text = Mathf.RoundToInt(time).ToString();

            // if the time is zero, end the game
            if (Mathf.RoundToInt(time) == 0)
            {
                endGame = true;
                gm.EndGame();
            }

        }

    }
}

