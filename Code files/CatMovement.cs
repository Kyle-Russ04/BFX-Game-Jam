using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float interactionDistance = 2f; // Distance within which player can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    public bool catIsHoldingLaser;
    public bool pickingUpLaser;

    void Update()
    {
        // Check for interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if(pickingUpLaser)
        {
            EquipLaser();
            pickingUpLaser = false;
        }

    }

    void EquipLaser()
    {
        catIsHoldingLaser = true;
        //update sprite
        //update UI
        Debug.Log("Cat is holding Laser");
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
