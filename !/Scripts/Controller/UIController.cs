using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listUI;
    [SerializeField] protected static UIController instance;
    public static UIController Instance => instance;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            this.PauseGame();
    }

    protected override void LoadComponent()
    {
        UIController.instance = this;
        base.LoadComponent();
        this.LoadListUI();
    }

    protected virtual void LoadListUI()
    {
        if (this.listUI.Count != 0) return;

        foreach (Transform UI in transform)
            this.listUI.Add(UI);
    }

    protected virtual void LoadUI(string nameUI)
    {
        foreach (Transform UI in this.listUI)
            if (nameUI.Equals(UI.name)) UI.gameObject.SetActive(true);
            else UI.gameObject.SetActive(false);
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
        this.LoadUI("PauseGameUI");
    }

    public virtual void LoseGame()
    {
        Time.timeScale = 0f;
        this.LoadUI("LoseGameUI");
    }

    public virtual void WinGame()
    {
        Time.timeScale = 0f;
        this.LoadUI("WinGameUI");
    }

    public virtual void Game()
    {
        Time.timeScale = 1;
        this.LoadUI("GameUI");
    }

    public virtual void Continue()
    {
        this.Game();
    }

    public virtual void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void QuitToMenu()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;

        if (nextSceneIndex < 0)
        {
            Debug.LogWarning("Scene don't exit!");
            return;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
