using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Scene don't exit!");
            return;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ShowCredits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

