using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //Closest Interactable
    public GameObject interactionIcon;

    void Start()
    {
        interactionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableInRange?.Interact();
        }
    }

    public void TryInteract()
{
    if (interactableInRange != null && interactableInRange.CanInteract())
    {
        interactableInRange.Interact();
    }
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if there is an interactable object in range & they can be interacted with
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            //once you enter the interaction radius -> icon will appear
            interactableInRange = interactable;
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            //once you leave the interaction range -> icon disappears
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }
    }
}
