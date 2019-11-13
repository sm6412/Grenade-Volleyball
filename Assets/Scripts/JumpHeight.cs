using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHeight : MonoBehaviour
{
    // force of jump
    public float jumpForce = 5f;

    // used for when the team jumps
    private bool pressedJump = false;

    // used for when the team must fall
    private bool releasedJump = false;

    // gravity
    public float gravityScale = 1f;

    // reference to rigidbody
    private Rigidbody2D rb;

    // bool for whether to start the timer
    private bool startTimer = false;
    // timer for how long jump can last
    public float jumpTimer = 0.5f;
    private float timer;

    // bool for when the team is on the ground
    private bool onGround = true;

    // reference to player controller script of left team
    private PlayerController pcLeft;
    // reference to player controller script of right team
    private PlayerController pcRight;

    private void Awake()
    {
        // get rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // set timer
        timer = jumpTimer;

        // get left and right team controller script
        pcLeft = GameObject.Find("Left Players").GetComponent<PlayerController>();
        pcRight = GameObject.Find("Right Players").GetComponent<PlayerController>();
    }



    private void Update()
    {
        // determine whether the team is on the ground
        if(this.transform.position.y <= -2.25f)
        {
            onGround = true;
        }

        // if on the ground, the team can jump. This avoids the double jump
        if (onGround)
        {
            // if pressing an up key, the team jumps
            if ((Input.GetKeyDown("w") && this.gameObject.tag == "left player") || (Input.GetKeyDown(KeyCode.UpArrow) && this.gameObject.tag == "right player"))
            {
                pressedJump = true;
            }
            // see whether the jump key is released, so the team can start falling. This allows for a jump determined by how long the jump key is held 
            if ((Input.GetKeyUp("w") && this.gameObject.tag == "left player") || (Input.GetKeyUp(KeyCode.UpArrow) && this.gameObject.tag == "right player"))
            {
                releasedJump = true;
                onGround = false;
                Idle(this.gameObject.tag);
            }
            // if another key is pressed, stop the jump
            if ((((Input.GetKeyDown("a") || Input.GetKeyDown("d")) && this.gameObject.tag == "left player")) || (((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && this.gameObject.tag == "right player")))
            {
                releasedJump = true;
                onGround = false;
                Idle(this.gameObject.tag);
            }
            // if the timer is started, see whether the jump can continue
            if (startTimer)
            {
                // decrement timer
                timer -= Time.deltaTime;
                // if the timer finishes, force the team to fall
                if (timer <= 0)
                {
                    releasedJump = true;
                    onGround = false;
                    Idle(this.gameObject.tag);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // see whether the team jumps up
        if (pressedJump)
        {
            StartJump();
        }
        // see whether the team's jump stops
        if (releasedJump)
        {
            StopJump();
        }
    }

    // make the teams jump up in the air with the jump sprites
    private void StartJump()
    {
        if (this.gameObject.tag == "left player")
        {
            Jump("left player");

        }
        else if (this.gameObject.tag == "right player")
        {
            Jump("right player");
        }

        rb.gravityScale = 0;
        rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    // make the jump stop, and the teams start falling
    private void StopJump()
    {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }

    // use the correct jump sprites according to which team jumped 
    public void Jump(string name)
    {
        // left team jumped
        if (name == "left player")
        {
            if (pcLeft.getLeftTeamFacingLeft() == true)
            {
                pcLeft.TeamLeftJump("left player");
            }
            else if (pcLeft.getLeftTeamFacingRight() == true)
            {
                pcLeft.TeamRightJump("left player");
            }

        }
        // right team jumped 
        else if (name == "right player")
        {
            if (pcRight.getRightTeamFacingLeft() == true)
            {
                pcRight.TeamLeftJump("right player");
            }
            else if (pcRight.getRightTeamFacingRight() == true)
            {
                pcRight.TeamRightJump("right player");
            }

        }
    }

    // set the sprite to the idle sprite when falling
    public void Idle(string name)
    {
        // left team is falling
        if (name == "left player")
        {
            if (pcLeft.getLeftTeamFacingLeft() == true)
            {
                pcLeft.TeamLeftIdle("left player");
            }
            else if (pcLeft.getLeftTeamFacingRight() == true)
            {
                pcLeft.TeamRightIdle("left player");
            }

        }
        // right team is falling
        else if(name == "right player")
        {
            if (pcRight.getRightTeamFacingLeft() == true)
            {
                pcRight.TeamLeftIdle("right player");
            }
            else if (pcRight.getRightTeamFacingRight() == true)
            {
                pcRight.TeamRightIdle("right player");
            }

        }
    }
}
