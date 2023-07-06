using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Achievement
{
    protected const string default_Name_Achievement = "Skeleton";

    [SerializeField] private string nameaAchievement = default_Name_Achievement;
    public string NameAchievement => this.nameaAchievement;

    [SerializeField] private int numberHaving = default;
    public int NumberHaving => this.numberHaving;

    public virtual void Increase(int number) => this.numberHaving = this.numberHaving + 1;
    public virtual bool IsEnough(int numberRequest) => (this.numberHaving >= numberRequest);
}

public class AchievementController : AutoMonobehaviour
{
    [SerializeField] private static AchievementController instance;
    public static AchievementController Instance => instance;
    protected override void LoadComponent() => AchievementController.instance = this;

    [SerializeField] private List<Achievement> achievements;
    
    public Achievement GetAchievementByName(string name)
    {
        foreach (Achievement achievement in this.achievements)
            if (achievement.NameAchievement.Equals(value: name)) return achievement;
        return null;
    }
}
