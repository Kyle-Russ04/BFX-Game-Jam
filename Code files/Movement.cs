using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Vector2 tranform;
    public Rigidbody2D Rb;
    public float moveSpeed = 2f; // Speed of the character
    public float distance = 2; //distance from cat
    public bool IsCatHoldingLaser = false;
    //checking if they are holding the laser ever loop
    public bool pickingUpLaser = false;
    //allows them to pick up the laser
    public LayerMask interactables;
    //anything that the player can pick up/ move
    public SpriteRenderer character_Sprite;
    public GameObject laser;
    //allows us to search for the laser in the game world

    public bool lookingRight = true;
    public bool lookingUp = false;
    //checks the direction you look in to change the sprite you get

    private void Start()
    {
        transform.position = Rb.position;
    }

    void Update()
    {
        // Get input for movement (Horizontal and Vertical)
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        //float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Create a new Vector3 for movement along the z-axis
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Move the character
        transform.position += movement;

        // Example: If you want to move along the z-axis directly with a specific key
        if (Input.GetKey(KeyCode.S)) // Move backwards along z
        {
            transform.position += new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)) // Move forwards along z
        {
            transform.position += new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        }

        if (moveHorizontal > 0 && !lookingRight)
        {
            reverse();
        }
        if (moveHorizontal < 0 && lookingRight)
        {
            reverse();
        }
        //reverses the sprite between left and right

        if (Input.GetKeyDown(KeyCode.E))
        {
            //press e to pick up the laser and use it
            interact();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeaveGame();
            //allows the player to go back to the home screen
        }
    }

    void interact()
    {
        Debug.Log("interacting with an object");
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, distance, interactables);
        Collider2D[] gothit = Physics2D.OverlapCircleAll(transform.position, distance, interactables);

        if (gothit != null && gothit.Length > 0)
        {
            for (int i = 0; i < gothit.Length; i++)
            {
                //checks each item in the list to see if the object name matches laser
                //to then equipt the laser
                if (gothit[i] == GameObject.Find("laser"))
                {
                    pickingUpLaser = true;
                    EquiptLaser();
                }

            }
        }
    }
    void EquiptLaser()
    {
        Debug.Log("Now holding laser");
        IsCatHoldingLaser = true;
        character_Sprite.sprite = null;
        //clear the sprite and then change it
        //or get rid of it and swap it with another one
        //add laser to the UI
    }

    void reverse()
    {
        lookingRight = !lookingRight;
        //changes the state of the bool

        character_Sprite.flipX = !character_Sprite.flipX;
        //flips the sprites to reverse the character direction
    }
    void LeaveGame()
    {
        Debug.Log("return to the main menu");
        //debug.log is for developer use
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //changes the scene you are on to the home/ main menu
        Cursor.lockState = CursorLockMode.Confined;
        //stops the cursor from being locked in place on the screen
        //(might not need this but here just in case)
        return;
    }
}