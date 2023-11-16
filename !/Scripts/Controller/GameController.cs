using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : AutoMonobehaviour
{
    protected const int default_Level = 1;

    [SerializeField] private int numberLevel = default_Level;
    [SerializeField] private int timeAppearBoss;
    [SerializeField] private GameObject chestWinGame;

    [SerializeField] private Boolean spawnBoss;
    [SerializeField] private Transform boss;
    [SerializeField] private LevelManagerSO levelManagerSO;
    public virtual void LoadLevelManagerSO() =>
         levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + Level.ToString());

    [SerializeField] private static GameController instance;
    public static GameController Instance => instance; 
    protected void LoadSingleton()
    {
        if (instance != null) return;
        GameController.instance = this;
        GameObject.DontDestroyOnLoad(target: gameObject);
    }

    protected virtual void LoadTimelineGame() =>
        timeAppearBoss = levelManagerSO.TimeAppearBoss;

    protected virtual void LoadChestWinGame() =>
        chestWinGame = GameObject.Find("Chest");

    protected override void LoadComponent() => LoadChestWinGame();

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadSingleton();
        LoadLevelManagerSO();
        LoadTimelineGame();
        chestWinGame.SetActive(false);
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        Application.targetFrameRate = 60;
    }

    public virtual void CoroutineStateMachineBehaviour(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) PauseGame();

        if (spawnBoss == true) return;
        if (Time.time < timeAppearBoss) return;
        boss.gameObject.SetActive(value: true);
        spawnBoss = true;
    }

    public virtual void WinGame()
    {
        /*Time.timeScale = 0f;*/
        Debug.Log("WInGame");
        chestWinGame.SetActive(true);
        StartCoroutine(AppearWinGameUI());
    }

    protected virtual IEnumerator AppearWinGameUI()
    {
        yield return new WaitForSeconds(1f);
        UIController.Instance.LoadWinGameUI();
        SFXSpawner.Instance.PlaySound("Sound_Win_Game");
    }

    public virtual void LoseGame()
    {
        Time.timeScale = 0f;
        UIController.Instance.LoadLoseGameUI();
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
        UIController.Instance.LoadPauseGameUI();
    }

    public int TimeAppearBoss => timeAppearBoss; 
    public int Level => numberLevel;
    public void SetNameLevel(int level) => numberLevel = level;
}

