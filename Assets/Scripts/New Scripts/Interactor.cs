using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private KeyCode keyToInteract;
    [SerializeField] private float interactRange = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToInteract))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        Ray r = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(r, out RaycastHit hitlnfo, interactRange))
        {
            if (hitlnfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                return interactObj;           
            }

        }
        return null;
    }
}
