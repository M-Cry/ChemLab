using UnityEngine;

public class PHPaperPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] BaseAcid LevelManager;
    [SerializeField] StepsManager stepsManager;
    [SerializeField] int actionIndex = 0;

    [SerializeField] string interactText;

    [SerializeField] Canvas pHPaperUI;
    [SerializeField] float spawnTime = 5f;
    float countDownTimer;

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
        }
    }

    private void Start()
    {
        countDownTimer = spawnTime;
    }

    private void Update()
    {
        if (!gameObject.activeSelf && countDownTimer <= 0f)
        {
            countDownTimer = spawnTime;
            gameObject.SetActive(true);
        }
        else
        {
            countDownTimer -= Time.deltaTime;
        }
    }
}
