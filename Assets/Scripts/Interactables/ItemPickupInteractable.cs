using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    [SerializeField] Level_1 invintory;

    [SerializeField] Level_1.ItemNames itemName;

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        if (itemName == Level_1.ItemNames.Item1)
        {
            invintory.hasItem1 = true;
            Destroy(gameObject);
        }
        else if (itemName == Level_1.ItemNames.Item2)
        {
            invintory.hasItem2 = true;
            Destroy(gameObject);
        }
    }

}
