using System;
using UnityEngine;

public class TimelineController : AutoMonobehaviour
{
    [SerializeField] private static TimelineController instance;
    [SerializeField] private int timeAppearBoss;
    [SerializeField] private Boolean spawnBoss;
    [SerializeField] private Transform boss;

    [SerializeField] private LevelManagerSO levelManagerSO;
    protected virtual void LoadLevelManagerSO()
    {
        if (this.levelManagerSO != null) return;
        string resPath = "Level/EasyLevel";
        this.levelManagerSO = Resources.Load<LevelManagerSO>(resPath);
        Debug.LogWarning(transform.name + ": Load GroupDecorObjectSO" + resPath, gameObject);
        this.LoadInformationMap();
    }

    public int TimeAppearBoss { get => timeAppearBoss; }
    public static TimelineController Instance { get => instance; }

    protected override void LoadComponent()
    {
        TimelineController.instance = this;
        base.LoadComponent();
        this.LoadLevelManagerSO();
        this.LoadInformationMap();
    }

    protected virtual void Update()
    {
        if (this.spawnBoss == true) return;
        if (Time.time < this.timeAppearBoss) return;
        this.boss.gameObject.SetActive(true);
        this.spawnBoss = true;
    }

    protected virtual void LoadInformationMap() =>
        this.timeAppearBoss = this.levelManagerSO.TimeAppearBoss;
}
