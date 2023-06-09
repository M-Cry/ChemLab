using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformPHTest : MonoBehaviour, IInteractable
{
    // controllers
    [SerializeField] BaseAcid LevelManager;
    [SerializeField] StepsManager stepsManager;

    [SerializeField] string interactText;
    [SerializeField] string interactTextWithNoPaper;

    [SerializeField] GameObject pHPaper;
    [SerializeField] GameObject pHPaperColor;
    [SerializeField] Material PaperColor;
    [SerializeField] Material LiquidColor;

    [SerializeField] int actionIndex;
    bool wait = false;

    Vector3 bottomPosition = new Vector3(-0.2800005f, 1.406f, -0.206f);
    Vector3 topPosition;
    [SerializeField] float animateDuration = 6f;
    float elapsedTime;

    bool animateGoingDown = false;
    bool animateGoingUp = false;

    public string GetInteractText()
    {
        if (LevelManager.ownPHPaper && stepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactText;
        else if (!LevelManager.ownPHPaper && stepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactTextWithNoPaper;
        else 
            return "Not Time yet";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        // if we own pH paper perform experament
        if (LevelManager.ownPHPaper && stepsManager.GetCurrentStepIndex() >= actionIndex && !wait)
        {
            animateGoingDown = true;
            LevelManager.pHPaperCount--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        topPosition = pHPaper.transform.localPosition;
        pHPaperColor.GetComponent<Renderer>().material = PaperColor;
        pHPaperColor.SetActive(false);
        pHPaper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (animateGoingDown)
        {
            if (!pHPaper.activeSelf)
            {
                pHPaperColor.SetActive(false);
                pHPaper.SetActive(true);
            }
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / animateDuration;
            pHPaper.transform.localPosition = Vector3.Lerp(topPosition, bottomPosition, percentageComplete);
            if (pHPaper.transform.localPosition == bottomPosition)
            {
                animateGoingDown = false;
                animateGoingUp = true;
                elapsedTime = 0f;
            }
            wait = true;
            pHPaperColor.SetActive(false);
        }
        else if (animateGoingUp)
        {
            if (!pHPaperColor.activeSelf)
                pHPaperColor.SetActive(true);
            elapsedTime += Time.deltaTime;
            float percentageComp1ete = elapsedTime / animateDuration;
            pHPaper.transform.localPosition = Vector3.Lerp(bottomPosition, topPosition, percentageComp1ete);
            if (pHPaper.transform.localPosition == topPosition)
            {
                animateGoingUp = false;
                elapsedTime = 0f;
            }
            wait = true;
        }
        else
        {
            wait = false;
        }
    }




}
