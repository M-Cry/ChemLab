using UnityEngine;

public class PHPaperPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] BaseAcid LevelManager;
    [SerializeField] StepsManager stepsManager;
    [SerializeField] int actionIndex = 0;

    [SerializeField] string interactText;

    [SerializeField] Canvas pHPaperUI;
    
    public bool respawn = false;

    public float countDownTimer;

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
        if (stepsManager.GetCurrentStepIndex() >= actionIndex)
        {
            pHPaperUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
            LevelManager.pHPaperCount++;
            respawn = true;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        
    }


}
