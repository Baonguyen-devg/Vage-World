using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public enum ActionMission
{
    Skill, Collect
}

[System.Serializable] public class ResourceMission
{
    private const string SKELETON_NAME = "Skeleton";

    [SerializeField] private string nameResourceMission = SKELETON_NAME;
    [SerializeField] private ActionMission actionFollow = ActionMission.Skill;
    [SerializeField] private int number;

    public ResourceMission(string nameResourceMission, ActionMission actionFollow, int number) =>
        (this.nameResourceMission, this.actionFollow, this.number) 
            = (nameResourceMission, actionFollow, number);

    public ActionMission ActionFollow => actionFollow;
    public string NameResourceMission => nameResourceMission;
    public int Number => number;
}

public class MissionManager : AutoMonobehaviour
{
    private static MissionManager instance;
    public static MissionManager Instance => instance;

    [SerializeField] private List<ResourceMission> missions;
    [SerializeField] protected bool isWinGame = false;

    protected override void Awake()
    {
        base.Awake();
        MissionManager.instance = this;
    }

    protected override IEnumerator LoadWaitForLongTime()
    {
        yield return StartCoroutine(base.LoadWaitForLongTime());
        Observable.EveryUpdate().Subscribe(_ => CheckEnoughMission()).AddTo(this);
    }

    private void CheckEnoughMission(int Count = 0)
    {
        if (isWinGame) return;
        foreach (ResourceMission mission in missions)
            if (Check(mission)) Count = Count + 1;

        if (Count == missions.Count) WinGame();
    }

    private bool Check(ResourceMission mission)
    {
        Achievement achievement = AchievementManager.Instance
            .GetAchievementByName(mission.NameResourceMission);

        if (achievement == null) return false;
        else if (achievement.IsEnough(mission.Number)) return true;
        return false;
    }

    private void WinGame()
    {
        isWinGame = true;
        GameManager.Instance.WinGame();
    }

    public List<ResourceMission> Missions => missions;
}
