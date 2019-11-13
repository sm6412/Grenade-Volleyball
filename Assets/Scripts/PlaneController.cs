using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // plane move speed
    public float moveSpeed;

    // int to determine which side the grenade is spawned on
    int side = 0;

    // reference to the game's game manager
    private GameManager gm;


    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        // use random to randomly decide which side the grenade spawns on
        float random = Random.Range(0, 2);
        if (random == 0)
        {
            side = 1;
        }
        else
        {
            side = 2;
        }

    }


    // Update is called once per frame
    void Update()
    {
        // see which way the plane is facing to determine how it moves
        if(gm.planeFaceRight == true)
        {
            this.transform.position += new Vector3(moveSpeed, 0, 0);
        }
        else if (gm.planeFaceLeft == true)
        {
            this.transform.position += new Vector3(-moveSpeed, 0, 0);
        }
        
        // drop grenade
        if(side==1 && this.transform.position.x >= -4.63f && gm.dropped==false)
        {
            gm.DropGrenadeLeft();
        }
        else if (side==2 && this.transform.position.x >= 4.63f && gm.dropped==false)
        {
            gm.DropGrenadeRight();
        }

    }
}
