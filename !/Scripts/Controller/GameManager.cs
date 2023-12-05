using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : AutoMonobehaviour
{
    public enum State
    {
        None,
        Loading,
        GamePlaying,
        GamePaused,
        GameFinished
    }

    private readonly int MAX_LEVEL = 6;
    private static GameManager instance;
    public static GameManager Instance => instance; 

    [SerializeField] private int _numberLevel = 1;
    [SerializeField] private int _timeAppearBoss;
    [SerializeField] private GameObject _chestWinGame;
    [SerializeField] private State _stateGame = State.None;

    [SerializeField] private bool _spawnBoss;
    [SerializeField] private Transform _boss;
    [SerializeField] private Transform _player;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        _chestWinGame = GameObject.Find("Chest");
        _player = GameObject.Find("Player").transform;
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        GameManager.instance = this;
        _chestWinGame.SetActive(false);

        _stateGame = State.Loading;
        Extension.StartDelayAction(this, 1f, () =>
        {
            _stateGame = State.GamePlaying;
            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_BACKGROUND);
        });
    }

    public void WinGame()
    {
        int level = DataManager.GetIntData(DataManager.INT_LEVEL);
        int unclokedLevel = DataManager.GetIntData(DataManager.INT_UNLOCKED_LEVEL);

        unclokedLevel = Mathf.Max(unclokedLevel, level + 1);
        unclokedLevel = Mathf.Min(MAX_LEVEL, unclokedLevel);
        DataManager.SetIntData(DataManager.INT_UNLOCKED_LEVEL, unclokedLevel);

        _chestWinGame.SetActive(true);
        _chestWinGame.transform.position = _player.position;
        _stateGame = State.GameFinished;

        Extension.StartDelayAction(this, 1.5f, () =>
        {
            UIController.Instance.LoadWinGameUI();
            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_WIN_GAME);
        });
    }

    public void LoseGame()
    {
        _stateGame = State.GameFinished;
        Extension.StartDelayAction(this, 1f, () => 
        {
            UIController.Instance.LoadLoseGameUI();
            SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_WIN_GAME);
        });
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _stateGame = State.GamePaused;
        UIController.Instance.LoadPauseGameUI();
    }

    public void CoroutineStateMachineBehaviour(IEnumerator coroutine) =>
        StartCoroutine(coroutine);

    public bool IsGamePlaying() => _stateGame == State.GamePlaying;
    public bool IsGameFinished() => _stateGame == State.GameFinished;
    public bool IsGamePaused() => _stateGame == State.GamePaused;

    public int TimeAppearBoss => _timeAppearBoss; 
    public int Level => _numberLevel;

    public void SetNameLevel(int level) => _numberLevel = level;
    public void SetGamePlaying() => _stateGame = State.GamePlaying;
}

