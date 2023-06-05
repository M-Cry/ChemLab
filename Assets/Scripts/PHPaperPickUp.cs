using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHPaperPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    [SerializeField] Canvas pHPaperUI;

    public bool ownPHPaper = false;

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
        pHPaperUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
        ownPHPaper = true;
    }
}
