using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAcid : MonoBehaviour
{
    [Header("pH Paper")]
    [SerializeField] PHPaperPickUp[] pHPapers;
    [SerializeField] float spawnTime = 5f;

    public int pHPaperCount = 0;
    public bool ownPHPaper;

    private void Awake()
    {
        for (int i = 0; i < pHPapers.Length; i++)
        {
            pHPapers[i].countDownTimer = spawnTime;
        }
    }

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

        // pH Paper Respawn
        for (int i = 0; i < pHPapers.Length; i++)
        {
            if (pHPapers[i].respawn && pHPapers[i].countDownTimer < 0f)
            {
                pHPapers[i].gameObject.SetActive(true);
                pHPapers[i].respawn = false;
                pHPapers[i].countDownTimer = spawnTime;
            }
            else if (pHPapers[i].respawn)
            {
                pHPapers[i].countDownTimer -= Time.deltaTime;
            }
        }
    }
}
