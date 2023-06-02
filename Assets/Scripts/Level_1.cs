using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1 : MonoBehaviour
{
    public enum ItemNames { Item1, Item2 };

    public bool hasItem1 = false;
    public bool hasItem2 = false;

    [SerializeField] GameObject uiItem1;
    [SerializeField] GameObject uiItem2;


    // Start is called before the first frame update
    void Start()
    {
        uiItem1.SetActive(false);
        uiItem2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasItem1)
        {
            uiItem1.SetActive(true);
        }
        else
        {
            uiItem1.SetActive(false);
        }

        if (hasItem2)
        {
            uiItem2.SetActive(true);
        }
        else
        {
            uiItem2.SetActive(false);
        }
    }
}
