using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionUIController : AutoMonobehaviour
{
    public class missionUI
    {
        [SerializeField] private string nameMission;
        public string NameMission => this.nameMission;

        [SerializeField] private int numberMissionRequest;
        [SerializeField] private GameObject UIMission;
        public GameObject GetUIMission => this.UIMission;

        public missionUI(string nameMission, int numberMissionRequest, GameObject uIMission) =>
            (this.nameMission, this.numberMissionRequest, this.UIMission) = (nameMission, numberMissionRequest, uIMission);

        public virtual float GetPercent(int numberPersent) => (float)numberPersent / this.numberMissionRequest;
    }

    [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
    [SerializeField] protected LevelManagerSO levelManagerSO = default;
    protected virtual void LoadLevelManagerSO() =>
         this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

    [SerializeField] private GameObject holder;
    private void LoadHolder() => this.holder = transform.Find("Holder").gameObject;

    [SerializeField] private GameObject missionUIPrefab;
    private void LoadMissionUIPrefab() => 
        this.missionUIPrefab = transform.Find(n: "Prefab")?.GetChild(index: 0).gameObject;

    [SerializeField] private List<missionUI> missionUIs;
    protected virtual void LoadMissionUIs() {
        this.missionUIs = new List<missionUI>();
        foreach (var mission in this.levelManagerSO.Missions)
        {
            if (mission.Name.Equals("This is a null element")) continue;
            string textMission = mission.ActionFollow + " " + mission.Number + " " + mission.Name + 's';
            GameObject newMissionUI = Instantiate(original: missionUIPrefab);

            this.missionUIs.Add(item: new missionUI(mission.Name, mission.Number, newMissionUI));
            newMissionUI.gameObject.SetActive(value: true);
            newMissionUI.GetComponentInChildren<Text>().text = textMission;
            newMissionUI.transform.SetParent(this.holder.transform);
            newMissionUI.transform.localScale = Vector3.one;
        }
    }

    protected override void LoadComponent()
    {
        this.LoadHolder();
        this.LoadMissionUIPrefab();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadLevelManagerSO();
        this.LoadMissionUIs();
    }

    protected virtual void Update()
    {
        if (this.missionUIs.Count == 0) return;
        foreach (missionUI mission in this.missionUIs)
        {
            float percent = mission.GetPercent(AchievementController.Instance.GetAchievementByName(mission.NameMission).NumberHaving);
            mission.GetUIMission.transform.Find("Process").Find("Background").GetComponent<Image>().fillAmount = percent;
            if (percent == 1f) mission.GetUIMission.transform.Find("Process").Find("Finished").gameObject.SetActive(true); 
        }

    }

    public virtual float GetPercentMissionByName(string name, int number)
    {
        foreach (missionUI mission in this.missionUIs)
            if (mission.NameMission.Equals(name)) return mission.GetPercent(number);
        return 0;
    }
}
