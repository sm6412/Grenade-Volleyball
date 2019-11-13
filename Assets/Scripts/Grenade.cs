using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grenade : MonoBehaviour
{
    // reference to the grenade's rigidbody
    private Rigidbody2D rb;

    // reference to the game's game manager
    private GameManager gm;

    // the gravity that is applied to the grenade when
    // a player first touches it
    public float gravityScaleOnHit;

    public void Update()
    {
        // keep track of which side of the game the grenade is on
        if (this.transform.position.x >= -9.15f && this.transform.position.x <= 0f)
        {
            gm.onRight = false;
            gm.onLeft = true;
        }
        else if (this.transform.position.x > 0f  && this.transform.position.x <= 9.15f)
        {
            gm.onRight = true;
            gm.onLeft = false;
        }
    }



    private void Awake()
    {
        // get a reference to the grenade's rigidbody
        rb = GetComponent<Rigidbody2D>();

        // get a reference to the game manager script
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // when a grenade is acted upon by an object, gravity is applied to the ball
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = gravityScaleOnHit;
    }


    // when the grenade hits the ground, it respawns on that side
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "left side")
        {
           gm.DestroyLeftGrenade();
        }
        if (collision.gameObject.tag == "right side")
        {
           gm.DestroyRightGrenade();
        }
    }
}
