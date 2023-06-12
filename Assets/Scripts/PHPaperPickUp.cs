using UnityEngine;

public class PHPaperPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] BaseAcid LevelManager;
    [SerializeField] StepsManager stepsManager;
    [SerializeField] int actionIndex = 0;

    [SerializeField] string interactText;

    public bool respawn = false;

    public float countDownTimer;

    public string GetInteractText()
    {
        if (stepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactText;
        else
            return "Not Time yet";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        if (stepsManager.GetCurrentStepIndex() >= actionIndex)
        {
            gameObject.SetActive(false);
            LevelManager.pHPaperCount++;
            respawn = true;
        }
    }
}
