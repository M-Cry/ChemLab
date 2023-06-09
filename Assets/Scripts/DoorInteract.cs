using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;

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
        SceneManager.LoadScene("MainMenu");
    }
}
