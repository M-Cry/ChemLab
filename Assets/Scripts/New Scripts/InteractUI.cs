using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interactor interactor;
    [SerializeField] private TextMeshProUGUI interactTextMeshProGUI;


    // Update is called once per frame
    void Update()
    {
        if (interactor.GetInteractableObject() != null)
        {
            Show(interactor.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
