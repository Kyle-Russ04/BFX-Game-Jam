using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactable : MonoBehaviour, IInteractable
{
    public enum InteractableType {Laser, Button, Door}
    public InteractableType interactType;
    public CatMovement catScript;

    public void Interact()
    {
        // Code for interaction (e.g., open a door, collect an item, etc.)
        Debug.Log("Interacted with " + gameObject.name + " " + interactType.ToString());
        if(interactType == InteractableType.Laser)
        {
            catScript.pickingUpLaser = true;
        }
        // You can add more functionality here, like destroying the object or changing its state
    }
}
