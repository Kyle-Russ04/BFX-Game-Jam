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
    public Movement catScript;

    public void Interact()
    {
        // Code for interaction (e.g., open a door, collect an item, etc.)
        Debug.Log("Interacted with " + gameObject.name + " " + interactType.ToString());
        if(interactType == InteractableType.Laser)
        {
            catScript.pickingUpLaser = true;
            this.transform.SetParent(catScript.transform);
            this.transform.position = catScript.transform.position;
        }
        // You can add more functionality here, like destroying the object or changing its state
    }
}
