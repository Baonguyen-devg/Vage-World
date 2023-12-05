using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : AutoMonobehaviour
{
    protected static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] protected List<Transform> listUI;
    [SerializeField] protected TMPro.TMP_Text levelText; 

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (listUI.Count != 0) return;
        foreach (Transform UI in transform)
            listUI.Add(UI);
    }
    #endregion

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        UIController.instance = this;
        levelText.text = "Level " + DataManager.GetIntData(DataManager.INT_LEVEL);
    }

    protected void Update()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        bool isEscapePressed = Manager.InputManager.GetInstance().IsEscapePress();
        if (isEscapePressed) GameManager.Instance.PauseGame();
    }

    public void LoadUI(string nameUI)
    {
        foreach (Transform UI in listUI)
            if (nameUI.Equals(UI.name)) 
                UI.gameObject.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        GameManager.Instance.SetGamePlaying();
        Game();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        int levelPresent = DataManager.GetIntData(DataManager.INT_LEVEL);
        LoadSceneManager.LoadScene("Level_" + levelPresent);
    }

    public void NextGame()
    {
        Time.timeScale = 1;
        int level = DataManager.GetIntData(DataManager.INT_LEVEL) + 1;
        DataManager.SetIntData(DataManager.INT_LEVEL, level);
        LoadSceneManager.LoadScene(LoadSceneManager.LOADING);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        LoadSceneManager.LoadScene(LoadSceneManager.MENU);
    }

    public void LoadPauseGameUI() => LoadUI("Pause_Game_UI");
    public void LoadLoseGameUI() => LoadUI("Lose_Game_UI");
    public void LoadWinGameUI() => LoadUI("Win_Game_UI");
    public void Game() => LoadUI("Game_UI");
}
