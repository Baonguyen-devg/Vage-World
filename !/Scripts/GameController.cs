using System;
using UnityEngine;

public class GameController : AutoMonobehaviour
{
    protected const int default_Level = 1;

    [SerializeField] private int level = default_Level;
    public int Level => this.level;
    public void SetNameLevel(int level) => 
        this.level = level;

    [SerializeField] private static GameController instance;
    public static GameController Instance => instance; 

    [SerializeField] private int timeAppearBoss;
    public int TimeAppearBoss => this.timeAppearBoss; 
    protected virtual void LoadInformationMap() =>
        this.timeAppearBoss = this.levelManagerSO.TimeAppearBoss;

    [SerializeField] private Boolean spawnBoss;
    [SerializeField] private Transform boss;
    [SerializeField] private LevelManagerSO levelManagerSO;
    protected virtual void LoadLevelManagerSO()
    { 
        this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());
        this.LoadInformationMap();
    }

    protected override void Awake()
    {
        if (instance != null) return;
        GameController.instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        GameController.instance = this;
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
}
