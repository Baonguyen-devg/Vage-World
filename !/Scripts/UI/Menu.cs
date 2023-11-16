using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : AutoMonobehaviour
{
    [SerializeField] private List<Button> buttonLevels = new List<Button>();
    private void LoadButtomLevels()
    {
        Transform holder = transform.Find("LevelTable")?.Find("Table");
        foreach (Transform button in holder) 
            buttonLevels.Add(button.GetComponent<Button>());
    }

    protected override void LoadComponent() => LoadButtomLevels();

    protected override void Awake()
    {
        base.Awake();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        foreach (Button button in buttonLevels) 
            ChangeStatusButton(button, false);

        for (int i = 0; i < unlockedLevel; i++)
            ChangeStatusButton(buttonLevels[i], true);
    }

    private void ChangeStatusButton(Button button, bool status)
    {
        button.interactable = status;
        button.transform.Find("Lock").gameObject.SetActive(!status);
    }
    
    public virtual void LoadEasyLevel(int Level)
    {
        GameController.Instance.SetNameLevel(level: Level);
        GameController.Instance.LoadLevelManagerSO();
        PlayGame();
    }

    public virtual void PlayGame() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public virtual void QuitGame() => Application.Quit();
}

