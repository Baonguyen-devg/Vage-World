using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class ResourceMission
{
    protected const string default_Name_Mission = "Skeleton";
    protected const string default_Action_Follow = "Skill";

    [SerializeField] private string nameResourceMission = default_Name_Mission;
    public string NameResourceMission => this.nameResourceMission;

    [SerializeField] private string actionFollow = default_Action_Follow;
    public string ActionFollow => this.actionFollow;

    [SerializeField] private int number;
    public int Number => this.number;

    public ResourceMission(string nameResourceMission, string action, int number) =>
        (this.nameResourceMission, this.actionFollow, this.number) = (nameResourceMission, action, number);
}

public class MissionController : AutoMonobehaviour
{
    [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
    [SerializeField] protected LevelManagerSO levelManagerSO = default;
    protected virtual void LoadLevelManagerSO() =>
         this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

    [Header(header: "[ List Resource Mission ]"), Space(height: 10)]
    [SerializeField] private List<ResourceMission> missions;
    protected virtual void LoadResourceMission()
    {
        this.missions.Clear();
        foreach (var missionSO in this.levelManagerSO.Missions)
            if (!missionSO.Name.Equals(value: "This is a null element"))
                this.missions.Add(new ResourceMission(nameResourceMission: missionSO.Name, action: missionSO.ActionFollow, number: missionSO.Number));
    }
    public List<ResourceMission> Missions => this.missions;

    protected override void LoadComponentInAwakeBefore() => this.LoadLevelManagerSO();

    protected override void LoadComponentInAwakeAfter() => this.LoadResourceMission();

    private void Update() => this.CheckEnoughMission();

    private void CheckEnoughMission(int Count = 0)
    {
        foreach (ResourceMission mission in this.missions)
            if (this.Check(mission: mission)) Count = Count + 1;

        if (Count == this.missions.Count) this.WinGame();
    }

    private bool Check(ResourceMission mission)
    {
        Achievement achievement = AchievementController.Instance.GetAchievementByName(name: mission.NameResourceMission);
        if (achievement == null) return false;
        else if (achievement.IsEnough(numberRequest: mission.Number)) return true;
        return false;
    }

    private void WinGame()
    {
        UIController.Instance.WinGame();
        if (GameController.Instance.Level >= PlayerPrefs.GetInt(key: "UnlockedLevel", defaultValue: 1))
        {
            PlayerPrefs.SetInt(key: "UnlockedLevel", value: PlayerPrefs.GetInt(key: "UnlockedLevel", defaultValue: 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
