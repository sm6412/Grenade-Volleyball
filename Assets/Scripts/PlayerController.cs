using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement speed of the players
    public float moveSpeed;

    // reference to the individual player's animations
    // left team
    private PlayerAnimation leftPlayer1;
    private PlayerAnimation leftPlayer2;
    // right team
    private PlayerAnimation rightPlayer1;
    private PlayerAnimation rightPlayer2;

    // determine which direction the teams are facing
    // left team
    private bool leftTeamFacingRight = true;
    private bool leftTeamFacingLeft = false;
    // right team
    private bool rightTeamFacingRight = false;
    private bool rightTeamFacingLeft = true;

    // bool keeps track of whether the team is on the ground
    private bool onGround;

    // int used to create movement animation
    int animationChecker = 0;

    int xRotationLimit = 20;
    int yRotationLimit = 20;
    int zRotationLimit = 20;




    public void Start()
    {
        // reference individual left team players
        leftPlayer1 = GameObject.Find("Left Left Player").GetComponent<PlayerAnimation>();
        leftPlayer2 = GameObject.Find("Left Right Player").GetComponent<PlayerAnimation>();

        // reference individual right team players
        rightPlayer1 = GameObject.Find("Right Left Player").GetComponent<PlayerAnimation>();
        rightPlayer2 = GameObject.Find("Right Right Player").GetComponent<PlayerAnimation>();

    }
    

    // create getter functions for which direction the teams are facing
    public bool getLeftTeamFacingRight()
    {
        return leftTeamFacingRight;
    }

    public bool getLeftTeamFacingLeft()
    {
        return leftTeamFacingLeft;
    }

    public bool getRightTeamFacingRight()
    {
       return rightTeamFacingRight;
    }

    public bool getRightTeamFacingLeft()
    {
       return rightTeamFacingLeft;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x > xRotationLimit)
        {
            transform.rotation = Quaternion.identity;
        }

        if (transform.rotation.eulerAngles.y > yRotationLimit)
        {
            transform.rotation = Quaternion.identity;
        }

        if (transform.rotation.eulerAngles.z > zRotationLimit)
        {
            transform.rotation = Quaternion.identity;
        }


        // check whether the team is on the ground
        if (this.transform.position.y <= -2.25f)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    

        // handle when the left team moves in midair 
        if (Input.GetKey("w") && Input.GetKey("a") && onGround==false && this.gameObject.tag == "left player")
        {
            TeamLeftIdle("left player");
        }
        else if (Input.GetKey("w") && Input.GetKey("d") && onGround == false && this.gameObject.tag == "left player")
        {
            TeamRightIdle("left player");
        }

        // handle when the right team moves in midair
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && onGround == false && this.gameObject.tag == "right player")
        {
            TeamLeftIdle("right player");
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && onGround == false && this.gameObject.tag == "right player")
        {
            TeamRightIdle("right player");
        }


        // handle idle position when the player is on the ground
        if (onGround)
        {
            // left team
            if(this.gameObject.tag == "left player")
            {
                if (leftTeamFacingLeft == true)
                {
                    TeamLeftIdle("left player");
                }
                else if (leftTeamFacingRight == true)
                {
                    TeamRightIdle("left player");
                }
            }
            // right team
            else if (this.gameObject.tag == "right player")
            {
                if (rightTeamFacingLeft == true)
                {
                    TeamLeftIdle("right player");
                }
                else if (rightTeamFacingRight == true)
                {
                    TeamRightIdle("right player");
                }
            }
        }// end if

        // handle movement for left players when 'a' or 'd' is held down
        if (Input.GetKey("a") && transform.position.x >= -4.59f && this.gameObject.tag == "left player")
        {
            // if the player is on the ground, display walking animation
            if (onGround)
            {
               TeamLeftAnimation("left player");
            }
            // move
            this.transform.position += new Vector3(-moveSpeed, 0, 0);
        }
        else if (Input.GetKey("d") && transform.position.x <= -0.81f && this.gameObject.tag == "left player")
        {
            // if the player is on the ground, display walking animation
            if (onGround)
            {
              TeamRightAnimation("left player");
            }
            // move
            this.transform.position += new Vector3(moveSpeed, 0, 0);
        }


        // handle movement for right players when arrow keys are held down
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= 5.38f && this.gameObject.tag == "right player")
        {
            // if the player is on the ground, display walking animation
            if (onGround)
            {
                TeamLeftAnimation("right player");
            }
            // move
            this.transform.position += new Vector3(-moveSpeed, 0, 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 9.30f && this.gameObject.tag == "right player")
        {
            // if the player is on the ground, display walking animation
            if (onGround)
            {
                TeamRightAnimation("right player");
            }
            // move
            this.transform.position += new Vector3(moveSpeed, 0, 0);
        }

        // increment animation checker
        animationChecker++;

    }

    // makes team jump facing right
    public void TeamRightJump(string name)
    {
        if(name == "left player")
        {
            leftTeamFacingRight = true;
            leftTeamFacingLeft = false;
            leftPlayer1.JumpRight();
            leftPlayer2.JumpRight();
        }
        else if (name == "right player")
        {
            rightTeamFacingRight = true;
            rightTeamFacingLeft = false;
            rightPlayer1.JumpRight();
            rightPlayer2.JumpRight();

        }

    }

    // makes team jump facing left
    public void TeamLeftJump(string name)
    {
        if (name == "left player")
        {
            leftTeamFacingRight = false;
            leftTeamFacingLeft = true;
            leftPlayer1.JumpLeft();
            leftPlayer2.JumpLeft();

        }
        else if (name == "right player")
        {
            rightTeamFacingRight = false;
            rightTeamFacingLeft = true;
            rightPlayer1.JumpLeft();
            rightPlayer2.JumpLeft();

        }

    }

    // makes a team idle facing left
    public void TeamLeftIdle(string name)
    {
        if (name == "left player")
        {
            leftTeamFacingRight = false;
            leftTeamFacingLeft = true;
            leftPlayer1.IdleLeft();
            leftPlayer2.IdleLeft();

        }
        else if (name == "right player")
        {
            rightTeamFacingRight = false;
            rightTeamFacingLeft = true;
            rightPlayer1.IdleLeft();
            rightPlayer2.IdleLeft();

        }

    }

    // makes a team idle facing right
    public void TeamRightIdle(string name)
    {
        if (name == "left player")
        {
            leftTeamFacingRight = true;
            leftTeamFacingLeft = false;
            leftPlayer1.IdleRight();
            leftPlayer2.IdleRight();

        }
        else if (name == "right player")
        {
            rightTeamFacingRight = true;
            rightTeamFacingLeft = false;
            rightPlayer1.IdleRight();
            rightPlayer2.IdleRight();

        }

    }

    // makes a team walk in the left direction
    public void TeamLeftAnimation(string name)
    {
        if (name == "left player")
        {
            leftTeamFacingRight = false;
            leftTeamFacingLeft = true;
            if (animationChecker % 2 == 0)
            {
                leftPlayer1.IdleLeft();
                leftPlayer2.IdleLeft();
            }
            else
            {
                leftPlayer1.MoveLeft();
                leftPlayer2.MoveLeft();
            }

        }
        else if (name == "right player")
        {
            rightTeamFacingRight = false;
            rightTeamFacingLeft = true;
            if (animationChecker % 2 == 0)
            {
                rightPlayer1.IdleLeft();
                rightPlayer2.IdleLeft();
            }
            else
            {
                rightPlayer1.MoveLeft();
                rightPlayer2.MoveLeft();
            }

        }


    }

    // makes a team walk in the right position
    public void TeamRightAnimation(string name)
    {
        if (name == "left player")
        {
            leftTeamFacingRight = true;
            leftTeamFacingLeft = false;

            if (animationChecker % 2 == 0)
            {
                leftPlayer1.IdleRight();
                leftPlayer2.IdleRight();
            }
            else
            {
                leftPlayer1.MoveRight();
                leftPlayer2.MoveRight();
            }
        }
        else if (name == "right player")
        {
            rightTeamFacingRight = true;
            rightTeamFacingLeft = false;

            if (animationChecker % 2 == 0)
            {
                rightPlayer1.IdleRight();
                rightPlayer2.IdleRight();
            }
            else
            {
                rightPlayer1.MoveRight();
                rightPlayer2.MoveRight();
            }

        }


    }


}
