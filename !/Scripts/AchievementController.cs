using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] public class Achievement
{
    protected const string default_Name_Achievement = "Skeleton";

    [SerializeField] private int numberHaving = default;
    [SerializeField] private string nameaAchievement = default_Name_Achievement;

    public virtual void Increase(int number) => numberHaving = numberHaving + 1;
    public virtual bool IsEnough(int numberRequest) => (numberHaving >= numberRequest);
    
    public string NameAchievement => nameaAchievement;
    public int NumberHaving => numberHaving;
}

public class AchievementController : AutoMonobehaviour
{
    [SerializeField] private static AchievementController instance;
    public static AchievementController Instance => instance;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => LoadCoinText();
    protected override void LoadComponentInAwakeBefore() => AchievementController.instance = this;

    [SerializeField] private List<Achievement> achievements;

    [SerializeField] private int coinNumber = 0;

    [SerializeField] private Text coinText;
    protected virtual void LoadCoinText() =>
        coinText = GameObject.Find("Canvas")?.transform.Find("Game_UI")?.Find("Coin")?.Find("Text_Number")?.GetComponent<Text>();

    public virtual void IncreaseCoin(int number)
    {
        coinNumber = coinNumber + number;
        coinText.text = coinNumber.ToString();
    }

    public virtual void DecreaseCoin(int number)
    {
        coinNumber = coinNumber - number;
        coinText.text = coinNumber.ToString();
    }

    public Achievement GetAchievementByName(string name)
    {
        foreach (Achievement achievement in achievements)
            if (achievement.NameAchievement.Equals(value: name)) return achievement;
        return null;
    }
}
