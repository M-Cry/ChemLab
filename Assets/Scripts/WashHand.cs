using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHand : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;

    [SerializeField] ParticleSystem runningWater;

    [SerializeField] AudioSource openSound;

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
        runningWater.Play();
        openSound.Play();
        BaseAcid.HandWashed = true;
        Reaction.handWashed = true;
    }


}
