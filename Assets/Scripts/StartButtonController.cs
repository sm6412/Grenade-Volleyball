using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        // get a reference to the sprite renderer
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // get the mouse position
        Vector3 mousePos = Input.mousePosition;
        // set the z axis of the mouse
        mousePos.z = 10;

        // grab the mouse pos with regards to the screen
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        // use raycasting to see if the player clicks on a game object
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);
        if (hit && Input.GetMouseButtonDown(0))
        {
            // if the user clicks on the start 
            // button, start the gameplay scene
            if (hit.collider.tag == "start")
            {
                // switch scene to gameplay
                SceneManager.LoadScene("Gameplay");
            }
        }
        else if (hit)
        {
            // if the mouse hovers over the button
            // make it turn green
            if (hit.collider.tag == "start")
            {
                sr.color = Color.green;
            }
        }
        else
        {
            sr.color = Color.white;
        }
    }
}
