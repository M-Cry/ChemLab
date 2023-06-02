using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    [SerializeField] Level_1 invintory;

    [SerializeField] bool notUsed = true;

    public string GetInteractText()
    {
        if (invintory.hasItem1 && invintory.hasItem2)
        {
            return interactText;
        }
        else if (!notUsed)
        {
            return "Experament in progress!";
        }
        return "Not all items picked up!";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        // check if all items needed are picked up
        if (invintory.hasItem1 && invintory.hasItem2 && notUsed)
        {
            transform.localScale = transform.localScale * 2;

            // remove items from invintory
            invintory.hasItem1 = false;
            invintory.hasItem2 = false;
            notUsed = false;
        }
    }
}
