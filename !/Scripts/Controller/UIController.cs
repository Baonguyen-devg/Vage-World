using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : AutoMonobehaviour
{
    [SerializeField] protected static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] protected List<Transform> listUI;
    protected virtual void LoadListUI()
    {
        if (this.listUI.Count != 0) return;
        foreach (Transform UI in transform)
            this.listUI.Add(item: UI);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListUI();
    }

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
        this.LoadUI("Load_Screen");
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Escape))
            this.LoadPauseGameUI();
    }

    public virtual void LoadUI(string nameUI)
    {
        foreach (Transform UI in this.listUI)
            if (nameUI.Equals(value: UI.name)) 
                UI.gameObject.SetActive(value: true);
    }

    public virtual void LoadPauseGameUI() => this.LoadUI(nameUI: "Pause_Game_UI");

    public virtual void LoadLoseGameUI() => this.LoadUI(nameUI: "Lose_Game_UI");

    public virtual void LoadWinGameUI() => this.LoadUI(nameUI: "Win_Game_UI");

    public virtual void Game() => this.LoadUI(nameUI: "Game_UI");

    public virtual void Continue()
    {
        Time.timeScale = 1;
        this.Game();
    }

    public virtual void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void NextGame()
    {
        Time.timeScale = 1;
        GameController.Instance.SetNameLevel(GameController.Instance.Level + 1);
        GameController.Instance.LoadLevelManagerSO();
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
