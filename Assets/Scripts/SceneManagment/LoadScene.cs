using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Loads scene by name
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
