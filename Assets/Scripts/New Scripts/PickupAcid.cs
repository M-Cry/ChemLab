using UnityEngine;

public class PickupAcid : MonoBehaviour, IInteractable
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
        Destroy(gameObject);
    }
}
