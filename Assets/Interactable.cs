using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(int catPlayer);
}

public class Interactable : MonoBehaviour, IInteractable
{
    public enum InteractableType {Laser, Button, Door}
    public InteractableType interactType;
    public CatInteraction1 catScript;
    public CatInteraction1 catScriptP2;


    public void Interact(int catPlayer)
    {
        // Code for interaction (e.g., open a door, collect an item, etc.)
        Debug.Log("Interacted with " + gameObject.name + " " + interactType.ToString());
        if(interactType == InteractableType.Laser)
        {
            if(catPlayer == 1)
            {
                catScript.pickingUpLaser = true;
                this.transform.SetParent(catScript.transform);
                this.transform.position = catScript.transform.position;
            }else if(catPlayer == 2)
            {
                catScriptP2.pickingUpLaser = true;
                this.transform.SetParent(catScriptP2.transform);
                this.transform.position = catScriptP2.transform.position;
            }
        }
        // You can add more functionality here, like destroying the object or changing its state
    }
}
