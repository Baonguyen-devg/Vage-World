using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : AutoMonobehaviour
{
    [SerializeField] private List<Button> buttonLevels = new List<Button>();
    private void LoadButtomLevels()
    {
        Transform holder = transform.Find(n: "LevelTable")?.Find(n: "Table");
        foreach (Transform button in holder) 
            this.buttonLevels.Add(item: button.GetComponent<Button>());
    }

    protected override void LoadComponent() => this.LoadButtomLevels();

    protected override void Awake()
    {
        base.Awake();
        int unlockedLevel = PlayerPrefs.GetInt(key: "UnlockedLevel", defaultValue: 1);

        foreach (Button button in this.buttonLevels) 
            this.ChangeStatusButton(button: button, status: false);

        for (int i = 0; i < unlockedLevel; i++)
            this.ChangeStatusButton(button: this.buttonLevels[i], status: true);
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
        this.PlayGame();
    }

    public virtual void PlayGame() =>
        SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex + 1);

    public virtual void QuitGame() => Application.Quit();
}

