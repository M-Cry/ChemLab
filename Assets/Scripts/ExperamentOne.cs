using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperamentOne : MonoBehaviour, IInteractable
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


    public string GetInteractText()
    {
        if (!Reaction.doingExperament1 && StepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactOneText;
        else if (Reaction.doingExperament1 && StepsManager.GetCurrentStepIndex() >= actionIndex)
            return interactTwoText;
        else
            return "Not Time Yet";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    void Awake()
    {
        containerOneLiquid.GetComponent<Renderer>().material = materialOneLiquid;
        containerTwoLiquid.GetComponent<Renderer>().material = materialTwoLiquid;
        containerThreeLiquid.GetComponent<Renderer>().material = materialThreeLiquid;
    }

    public void Interact(Transform interactorTransform)
    {
        if (!Reaction.doingExperament1 && StepsManager.GetCurrentStepIndex() >= actionIndex)
        {


            Reaction.doingExperament1 = true;
        }
        else if (Reaction.doingExperament1 && StepsManager.GetCurrentStepIndex() >= actionIndex)
        {
            containerOneLiquid.SetActive(false);
            containerTwoLiquid.SetActive(true);
            containerThreeLiquid.SetActive(false);

            Reaction.finishedExperament1 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
