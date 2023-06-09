using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DisableOnPause : MonoBehaviour
{
    [SerializeField] GameObject[] ObjectsToDisable;
    [SerializeField] System.ComponentModel.Component[] ComponetsToDisable;
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            for (int i = 0; i < ObjectsToDisable.Length; i++)
            {
                if (ObjectsToDisable.Length == 0) break;
                ObjectsToDisable[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < ObjectsToDisable.Length; i++)
            {
                if (ObjectsToDisable.Length == 0) break;
                ObjectsToDisable[i].SetActive(false);
            }
        }
    }
}
