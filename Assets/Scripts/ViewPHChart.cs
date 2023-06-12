using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPHChart : MonoBehaviour, IInteractable
{
    [SerializeField] StepsManager stepsManager;

    [SerializeField] string interactText;
    [SerializeField] Canvas pHChart;
    [SerializeField] KeyCode keyToQuitPHChart;
    [SerializeField] int actionIndex;

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
            pHChart.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToQuitPHChart))
        {
            pHChart.gameObject.SetActive(false);
        }
    }
}
