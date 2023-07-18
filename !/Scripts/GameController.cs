using System;
using UnityEngine;

public class GameController : AutoMonobehaviour
{
    protected const int default_Level = 1;

    [SerializeField] private int numberLevel = default_Level;
    public int Level => this.numberLevel;
    public void SetNameLevel(int level) => 
        this.numberLevel = level;

    [SerializeField] private static GameController instance;
    public static GameController Instance => instance; 
    protected void LoadSingleton()
    {
        if (instance != null) return;
        GameController.instance = this;
        GameObject.DontDestroyOnLoad(target: gameObject);
    }

    [SerializeField] private int timeAppearBoss;
    public int TimeAppearBoss => this.timeAppearBoss; 
    protected virtual void LoadTimelineGame() =>
        this.timeAppearBoss = this.levelManagerSO.TimeAppearBoss;

    [SerializeField] private Boolean spawnBoss;
    [SerializeField] private Transform boss;
    [SerializeField] private LevelManagerSO levelManagerSO;
    protected virtual void LoadLevelManagerSO() =>
         this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

    protected override void LoadComponentInAwakeBefore()
    {
        this.LoadSingleton();
        this.LoadLevelManagerSO();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        this.LoadTimelineGame();
    }

    protected virtual void Update()
    {
        if (this.spawnBoss == true) return;
        if (Time.time < this.timeAppearBoss) return;
        this.boss.gameObject.SetActive(value: true);
        this.spawnBoss = true;
    }
}
