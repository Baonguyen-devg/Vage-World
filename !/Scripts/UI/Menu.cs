using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : AutoMonobehaviour
{
    private List<Button> _buttonLevels = new List<Button>();

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        Transform holder = transform.Find("LevelTable")?.Find("Table");
        foreach (Transform button in holder)
            _buttonLevels.Add(button.GetComponent<Button>());
    }
    #endregion

    [ContextMenu("Reset Unlocked Level")]
    private void ResetUnlockedLevel() =>
         DataManager.SetIntData(DataManager.INT_UNLOCKED_LEVEL, 1);

    protected override void Awake()
    {
        base.Awake();
        int unlockedLevel = DataManager.GetIntData(DataManager.INT_UNLOCKED_LEVEL);

        foreach (Button button in _buttonLevels) 
            ChangeStatusButton(button, false);

        for (int i = 0; i < unlockedLevel; i++)
            ChangeStatusButton(_buttonLevels[i], true);
    }

    private void ChangeStatusButton(Button button, bool status)
    {
        button.interactable = status;
        button.transform.Find("Lock").gameObject.SetActive(!status);
    }
    
    public virtual void LoadEasyLevel(int Level)
    {
        DataManager.SetIntData(DataManager.INT_LEVEL, Level);
        LoadSceneManager.LoadScene(LoadSceneManager.LOADING);
    }

    public virtual void QuitGame() => Application.Quit();
}

