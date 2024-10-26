using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    public float interactionDistance = 2f; // Distance within which player can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    public bool catIsHoldingLaser;
    public bool pickingUpLaser;
    public GameObject othercat;
    public Transform laser;
    public Movement endtask;
    public float lives = 3f;

    public CatCollarGlow CatCollar;
    public 

    void Update()
    {
        // Check for interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (catIsHoldingLaser == false)
            {
                Interact();
            }
            
            if (catIsHoldingLaser && (CatCollar.Distance.magnitude <= 1))
            {
                Debug.Log("they are close");
                laser.DetachChildren();
                catIsHoldingLaser = false;
                
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
        Debug.Log("Cat is holding Laser");
        Debug.Log(catIsHoldingLaser);
        Debug.Log(pickingUpLaser);
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
                interactable.Interact();
            }
        }
    }
}
