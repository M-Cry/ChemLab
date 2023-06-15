using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperamentTwo : MonoBehaviour, IInteractable
{
    [SerializeField] ReactionStepsManager StepsManager;

    [SerializeField] int actionIndex;

    [SerializeField] string interactOneText;
    [SerializeField] string interactTwoText;

    [SerializeField] GameObject containerOneLiquid;
    [SerializeField] GameObject containerTwoLiquid;
    [SerializeField] GameObject containerThreeLiquid;

    [SerializeField] Material materialOneLiquid;
    [SerializeField] Material materialTwoLiquid;
    [SerializeField] Material materialThreeLiquid;

    [SerializeField] GameObject pHPaperOne;
    [SerializeField] GameObject pHPaperTwo;
    [SerializeField] GameObject pHPaperThree;

    [SerializeField] GameObject pHPaperColorOne;
    [SerializeField] GameObject pHPaperColorTwo;
    [SerializeField] GameObject pHPaperColorThree;

    [SerializeField] Material paperColorOne;
    [SerializeField] Material paperColorTwo;
    [SerializeField] Material paperColorThree;

    bool wait = false;

    Vector3 bottomPosition = new Vector3(-0.2800005f, 1.406f, -0.206f);
    Vector3 topPosition;
    [SerializeField] float animateDuration = 6f;
    float elapsedTimeOne;
    float elapsedTimeTwo;
    float elapsedTimeThree;

    bool animateGoingDownFirst = false;
    bool animateGoingDownSecond = false;
    bool animateGoingUpFirst = false;
    bool animateGoingUpSecond = false;

    public string GetInteractText()
    {
        if (!Reaction.doingExperament2 && StepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactOneText;
        else if (Reaction.doingExperament2 && StepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactTwoText;
        else
            return "Not Time Yet";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    void Start()
    {
        topPosition = pHPaperOne.transform.localPosition;

        containerOneLiquid.GetComponent<Renderer>().material = materialOneLiquid;
        containerTwoLiquid.GetComponent<Renderer>().material = materialTwoLiquid;
        containerThreeLiquid.GetComponent<Renderer>().material = materialThreeLiquid;

        pHPaperColorOne.GetComponent<Renderer>().material = paperColorOne;
        pHPaperColorTwo.GetComponent<Renderer>().material = paperColorTwo;
        pHPaperColorThree.GetComponent<Renderer>().material = paperColorThree;

        pHPaperColorOne.SetActive(false);
        pHPaperColorTwo.SetActive(false);
        pHPaperColorThree.SetActive(false);

        pHPaperOne.SetActive(false);
        pHPaperTwo.SetActive(false);
        pHPaperThree.SetActive(false);
    }

    public void Interact(Transform interactorTransform)
    {
        if (!Reaction.doingExperament2 && StepsManager.GetCurrentStepIndex() >= actionIndex && !wait)
        {
            animateGoingDownFirst = true;

            Reaction.doingExperament2 = true;
        }
        else if (Reaction.doingExperament2 && StepsManager.GetCurrentStepIndex() >= actionIndex && !wait)
        {
            containerOneLiquid.SetActive(false);
            containerTwoLiquid.SetActive(true);
            containerThreeLiquid.SetActive(false);

            animateGoingDownSecond = true;

            Reaction.finishedExperament2 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animateGoingDownFirst)
        {
            if (!pHPaperOne.activeSelf || !pHPaperTwo.activeSelf)
            {
                pHPaperColorOne.SetActive(false);
                pHPaperColorThree.SetActive(false);
                pHPaperOne.SetActive(true);
                pHPaperThree.SetActive(true);
            }
            elapsedTimeOne += Time.deltaTime;
            elapsedTimeThree += Time.deltaTime;
            float percentageCompleteOne = elapsedTimeOne / animateDuration;
            float percentageCompleteThree = elapsedTimeThree / animateDuration;
            pHPaperOne.transform.localPosition = Vector3.Lerp(topPosition, bottomPosition, percentageCompleteOne);
            pHPaperThree.transform.localPosition = Vector3.Lerp(topPosition, bottomPosition, percentageCompleteThree);
            if (pHPaperOne.transform.localPosition == bottomPosition && pHPaperThree.transform.localPosition == bottomPosition)
            {
                animateGoingDownFirst = false;
                animateGoingUpFirst = true;
                elapsedTimeOne = 0f;
                elapsedTimeThree = 0f;
            }
            wait = true;
            pHPaperColorOne.SetActive(false);
            pHPaperColorThree.SetActive(false);
        }
        else if (animateGoingUpFirst)
        {
            if (!pHPaperColorOne.activeSelf || !pHPaperColorThree.activeSelf)
            {
                pHPaperColorOne.SetActive(true);
                pHPaperColorThree.SetActive(true);
            }
            elapsedTimeOne += Time.deltaTime;
            elapsedTimeThree += Time.deltaTime;
            float percentageCompleteOne = elapsedTimeOne / animateDuration;
            float percentageCompleteThree = elapsedTimeThree / animateDuration;
            pHPaperOne.transform.localPosition = Vector3.Lerp(bottomPosition, topPosition, percentageCompleteOne);
            pHPaperThree.transform.localPosition = Vector3.Lerp(bottomPosition, topPosition, percentageCompleteThree);
            if (pHPaperOne.transform.localPosition == topPosition && pHPaperThree.transform.localPosition == topPosition)
            {
                animateGoingUpFirst = false;
                elapsedTimeOne = 0f;
                elapsedTimeThree = 0f;
            }
            wait = true;
        }
        else
        {
            wait = false;
        }

        if (animateGoingDownSecond)
        {
            if (!pHPaperTwo.activeSelf)
            {
                pHPaperColorTwo.SetActive(false);
                pHPaperTwo.SetActive(true);
            }
            elapsedTimeTwo += Time.deltaTime;
            float percentageCompleteTwo = elapsedTimeTwo / animateDuration;
            pHPaperTwo.transform.localPosition = Vector3.Lerp(topPosition, bottomPosition, percentageCompleteTwo);
            if (pHPaperTwo.transform.localPosition == bottomPosition)
            {
                animateGoingDownSecond = false;
                animateGoingUpSecond = true;
                elapsedTimeTwo = 0f;
            }
            wait = true;
            pHPaperColorTwo.SetActive(false);
        }
        else if (animateGoingUpSecond)
        {
            if (!pHPaperColorTwo.activeSelf)
                pHPaperColorTwo.SetActive(true);
            elapsedTimeTwo += Time.deltaTime;
            float percentageComp1eteTwo = elapsedTimeTwo / animateDuration;
            pHPaperTwo.transform.localPosition = Vector3.Lerp(bottomPosition, topPosition, percentageComp1eteTwo);
            if (pHPaperTwo.transform.localPosition == topPosition)
            {
                animateGoingUpSecond = false;
                elapsedTimeTwo = 0f;
            }
            wait = true;
        }
        else
        {
            wait = false;
        }
    }
}
