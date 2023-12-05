using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SerializeField] 
public class MissionUI
{
    private string nameMission;
    private int numberMissionRequest;
    private GameObject UIMission;

    public MissionUI(string nameMission, int numberMissionRequest, GameObject uIMission) =>
        (this.nameMission, this.numberMissionRequest, this.UIMission)
            = (nameMission, numberMissionRequest, uIMission);

    public string NameMission => nameMission;
    public GameObject GetUIMission => UIMission;
    public float GetPercent(int numberPersent) => (float)numberPersent / numberMissionRequest;
}

public class MissionUIManager : AutoMonobehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private Transform missionUIPrefab;
    [SerializeField] private List<MissionUI> missionUIs = new List<MissionUI>();

    private List<Image> _missionUIImages = new List<Image>();
    private List<Transform> _missionUIIFinishedIcons = new List<Transform>();

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        holder = transform.Find("Holder");
        missionUIPrefab = transform.Find("Prefab").GetChild(0);
    }

    protected virtual void LoadMissionUIs() {
        missionUIs.Clear();
        foreach (var mission in MissionManager.Instance.Missions)
        {
            string textMission = StringBuilder(mission);
            GameObject newMissionUI = Instantiate(missionUIPrefab.gameObject);

            MissionUI missonUI = new MissionUI(mission.NameResourceMission, mission.Number, newMissionUI);
            missionUIs.Add(missonUI);

            MissionUICustomize(textMission, newMissionUI);
            AddImageAndFinishedIcon(missonUI);
        }
    }

    private void AddImageAndFinishedIcon(MissionUI missonUI)
    {
        Image imageUI = missonUI.GetUIMission.transform.Find("Process").Find("Background").GetComponent<Image>();
        Transform finishedIcon = missonUI.GetUIMission.transform.Find("Process").Find("Finished");

        _missionUIImages.Add(imageUI);
        _missionUIIFinishedIcons.Add(finishedIcon);
    }

    private void MissionUICustomize(string textMission, GameObject newMissionUI)
    {
        newMissionUI.transform.SetParent(holder);

        newMissionUI.GetComponentInChildren<TMP_Text>().text = textMission;
        newMissionUI.transform.localScale = Vector3.one;
        newMissionUI.gameObject.SetActive(true);
    }
    #endregion

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadMissionUIs();
    }

    protected virtual void Update()
    {
        if (missionUIs.Count == 0) return;
        foreach (MissionUI mission in missionUIs)
        {
            Achievement achievement = AchievementManager.Instance.GetAchievementByName(mission.NameMission);
            float percent = mission.GetPercent(achievement.NumberHaving);

            int index = missionUIs.IndexOf(mission);
            _missionUIImages[index].fillAmount = percent;
            if (percent == 1f) _missionUIIFinishedIcons[index].gameObject.SetActive(true);
        }
    }

    public virtual float GetPercentMissionByName(string name, int number)
    {
        foreach (MissionUI mission in missionUIs)
            if (mission.NameMission.Equals(name)) return mission.GetPercent(number);
        return 0;
    }

    private string StringBuilder(ResourceMission mission)
    {
        StringBuilder textMissiton = new StringBuilder()
            .Append(mission.ActionFollow).Append(" ")
            .Append(mission.Number).Append(" ")
            .Append(mission.NameResourceMission).Append("s");
        return textMissiton.ToString();
    }
}
