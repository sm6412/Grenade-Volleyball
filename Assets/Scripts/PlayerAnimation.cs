using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class handles when the sprite changes in order
// to create the illusion of an animation
public class PlayerAnimation : MonoBehaviour
{

    // import sprites that are displayed
    // during different frames of an
    // animation
    public Sprite faceRight;
    public Sprite faceLeft;
    public Sprite moveRight;
    public Sprite moveLeft;
    public Sprite jumpRight;
    public Sprite jumpLeft;

    // sprite renderer of individual player
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        // get a reference to the sprite renderer
        sr = GetComponent<SpriteRenderer>();
        // set the sprite's size
        sr.size = new Vector2(1f, 1f);

    }

    // sets sprite to its idle position facing right
    public void IdleRight()
    {
        sr.sprite = faceRight;
    }

    // sets sprite to its idle position facing left
    public void IdleLeft()
    {
        sr.sprite = faceLeft;
    }

    // sets sprite to its walking sprite facing right
    public void MoveRight()
    {
        sr.sprite = moveRight;
    }

    // sets sprite to its walking sprite facing left
    public void MoveLeft()
    {
        sr.sprite = moveLeft;
    }

    // sets sprite to jump sprite facing right
    public void JumpRight()
    {
        sr.sprite = jumpRight;
    }

    // sets sprite to jump sprite facing left
    public void JumpLeft()
    {
        sr.sprite = jumpLeft;
    }
}
