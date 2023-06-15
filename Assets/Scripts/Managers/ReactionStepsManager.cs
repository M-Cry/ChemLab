using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionStepsManager : MonoBehaviour
{
    public GameObject[] Steps;
    private int currentStepIndex = 0;

    [SerializeField] private float waitTime = 2f;
    private float waitTimeValue;

    void Start()
    {
        waitTimeValue = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Steps.Length; i++)
        {
            if (i == currentStepIndex)
            {
                Steps[i].SetActive(true);
            }
            else
            {
                Steps[i].SetActive(false);
            }
        }

        if (currentStepIndex == 0)
        {
            if (waitTime <= 0)
            {
                if (Reaction.handWashed)
                {
                    currentStepIndex++;
                    waitTime = waitTimeValue;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (currentStepIndex == 1)
        {
            if (waitTime <= 0)
            {
                if (Reaction.doingExperament1)
                {
                    currentStepIndex++;
                    waitTime = waitTimeValue;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (currentStepIndex == 2)
        {
            if (waitTime <= 0)
            {
                if (Reaction.finishedExperament1)
                {
                    currentStepIndex++;
                    waitTime = waitTimeValue;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (currentStepIndex == 3)
        {
            if (waitTime <= 0)
            {
                if (Reaction.doingExperament2)
                {
                    currentStepIndex++;
                    waitTime = waitTimeValue;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (currentStepIndex == 4)
        {
            if (waitTime <= 0)
            {
                if (Reaction.finishedExperament2)
                {
                    currentStepIndex++;
                    waitTime = waitTimeValue;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public int GetCurrentStepIndex()
    {
        return currentStepIndex;
    }
}

