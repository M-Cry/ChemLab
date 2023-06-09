using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperamentsMenu : MonoBehaviour
{
    public void LoadExperament(string experamentName)
    {
        SceneManager.LoadScene(experamentName);
    }
}
