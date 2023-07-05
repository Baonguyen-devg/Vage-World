using System;
using UnityEngine;

public class GameController : AutoMonobehaviour
{
    protected const string default_Level = "EasyLevel_1";

    [SerializeField] private string nameLevel = default_Level;
    public string NameLevel => this.nameLevel;
    public void SetNameLevel(string nameLevel) => 
        this.nameLevel = nameLevel;

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
        this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + GameController.Instance.NameLevel);
        this.LoadInformationMap();
    }

    protected override void Awake()
    {
        base.Awake();
        GameObject.DontDestroyOnLoad(gameObject);
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
}
