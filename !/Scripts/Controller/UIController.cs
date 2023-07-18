using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listUI;
    protected virtual void LoadListUI()
    {
        if (this.listUI.Count != 0) return;
        foreach (Transform UI in transform)
            this.listUI.Add(item: UI);
    }

    [SerializeField] protected static UIController instance;
    public static UIController Instance => instance;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Escape))
            this.PauseGame();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
    }

    protected override void LoadComponent() => this.LoadListUI();

    protected virtual void LoadUI(string nameUI)
    {
        foreach (Transform UI in this.listUI)
            if (nameUI.Equals(value: UI.name)) UI.gameObject.SetActive(value: true);
            else UI.gameObject.SetActive(value: false);
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
        this.LoadUI(nameUI: "PauseGameUI");
    }

    public virtual void LoseGame()
    {
        Time.timeScale = 0f;
        this.LoadUI(nameUI: "LoseGameUI");
    }

    public virtual void WinGame()
    {
        Time.timeScale = 0f;
        this.LoadUI(nameUI: "WinGameUI");
    }

    public virtual void Game()
    {
        Time.timeScale = 1;
        this.LoadUI(nameUI: "GameUI");
    }

    public virtual void Continue() => this.Game();

    public virtual void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void QuitToMenu()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;

        if (nextSceneIndex < 0)
        {
            Debug.LogWarning(message: "Scene don't exit!");
            return;
        }
        SceneManager.LoadScene(sceneBuildIndex: nextSceneIndex);
    }
}
