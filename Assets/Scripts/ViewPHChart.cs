using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPHChart : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    [SerializeField] Canvas pHChart;
    [SerializeField] KeyCode keyToQuitPHChart;

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
