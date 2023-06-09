using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour
{

    public GameObject[] Steps;
    private int currentStepIndex = 0;

    [SerializeField] private float waitTime = 2f;

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

        }
        else if (currentStepIndex == 1)
        {
            if (waitTime <= 0)
            {

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
