using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] public class Achievement
{
    protected const string DEFAULT_ACHIEVEMENT = "Skeleton";

    [SerializeField] private int numberHaving;
    [SerializeField] private string nameaAchievement = DEFAULT_ACHIEVEMENT;

    public virtual void Increase(int number) => numberHaving = numberHaving + 1;
    public virtual bool IsEnough(int numberRequest) => (numberHaving >= numberRequest);
    
    public string NameAchievement => nameaAchievement;
    public int NumberHaving => numberHaving;
}

public class AchievementManager : AutoMonobehaviour
{
    private static AchievementManager instance;
    public static AchievementManager Instance => instance;

    [SerializeField] private List<Achievement> achievements;
    [SerializeField] private int coinNumber = 0;
    [SerializeField] private TMP_Text coinText;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => LoadCoinText();
    protected override void LoadComponentInAwakeBefore() => AchievementManager.instance = this;

    protected virtual void LoadCoinText() =>
        coinText = GameObject.Find("Canvas").transform.Find("Game_UI")
            .Find("Coin").Find("Text_Number").GetComponent<TMP_Text>();

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
