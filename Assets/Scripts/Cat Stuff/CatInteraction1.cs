using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction1 : MonoBehaviour
{
    public float interactionDistance = 2f; // Distance within which player can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    public int catPlayer;
    public bool catIsHoldingLaser;
    public bool pickingUpLaser;
    public GameObject othercat;
    public Transform laser;
    public movementByWill endtask;
    public float lives = 3f;

    public CatCollarGlow CatCollar;

    void Update()
    {
        // Check for interaction input
        if(catPlayer == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
                pickingUpLaser = true;
                othercat.GetComponent<CatInteraction1>().catIsHoldingLaser = false;
            }
        }else if (catPlayer == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Interact();
                pickingUpLaser = true;
                othercat.GetComponent<CatInteraction1>().catIsHoldingLaser = false;
            }
        }

        if(pickingUpLaser)
        {
            EquipLaser();
            pickingUpLaser = false;
        }

        if (lives == 0)
        {
            Debug.Log("Game ends");
            endtask.LeaveGame();
        }
    }

    void EquipLaser()
    {
        catIsHoldingLaser = true;
        //update sprite
        //update UI
        //Debug.Log("Cat is holding Laser");
        //Debug.Log(catIsHoldingLaser);
        //Debug.Log(pickingUpLaser);
    }

    void Interact()
    {
        // Perform a raycast to check for interactable objects
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, interactionDistance, interactableLayer);
        Collider2D[] hit = Physics2D.OverlapCircleAll (transform.position, interactionDistance, interactableLayer);

        foreach (var collider in hit)
        {
            // Check if the collider has an interactable component
            IInteractable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(catPlayer);
            }
        }
    }

    public void changeSprite()
    {
        if (lives == 2)
        {
            //change sprite
        }
    }
}

