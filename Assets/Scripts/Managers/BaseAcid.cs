using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAcid : MonoBehaviour
{
    public int pHPaperCount = 0;
    public bool ownPHPaper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pHPaperCount > 0)
        {
            ownPHPaper = true;
        }
        else
        {
            ownPHPaper = false;
        }
    }
}
