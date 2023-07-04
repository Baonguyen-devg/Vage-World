using System;
using UnityEngine;

public class GameController : AutoMonobehaviour
{
    [SerializeField] private static GameController instance;
    public static GameController Instance => instance; 

    [SerializeField] private int timeAppearBoss;
    public int TimeAppearBoss => this.timeAppearBoss; 

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

    protected override void LoadComponent()
    {
        GameController.instance = this;
        base.LoadComponent();
        this.LoadLevelManagerSO();
        this.LoadInformationMap();
    }

    protected virtual void Update()
    {
        if (this.spawnBoss == true) return;
        if (Time.time < this.timeAppearBoss) return;
        this.boss.gameObject.SetActive(value: true);
        this.spawnBoss = true;
    }

    protected virtual void LoadInformationMap() =>
        this.timeAppearBoss = this.levelManagerSO.TimeAppearBoss;
}
