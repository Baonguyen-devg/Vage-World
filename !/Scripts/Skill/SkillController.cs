using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SkillController : AutoMonobehaviour
{
    private readonly int ITEM_NUMBER = 3;

    private List<Transform> _items = new List<Transform>();
    public Dictionary<Transform, int> listRandomItems = new Dictionary<Transform, int>();

    [SerializeField] private int minimumItem = 1;
    [SerializeField] private int maximumItem = 5;
    [SerializeField] private float timeDelay = 10;
    [SerializeField] private EventSO EventPlayerShoote; 

    private float _timeCounter = 0;
    private bool _canUse;
    private bool _isUpdate = false;

    protected override void Start()
    {
        base.Start();
        EventPlayerShoote.Subscribe(SetTimeCounter);
        Observable.EveryUpdate().Subscribe(_ => CountDown()).AddTo(this);
    }

    protected virtual void CountDown()
    {
        if (!_isUpdate) return;
        if (_timeCounter >= 0)
        {
            _timeCounter = _timeCounter - Time.deltaTime;
            if (_timeCounter <= 0)
            {
                _canUse = true;
                SkillManager.Instance.ChangeStatusSkills();
            } 
        }
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        _items = new List<Transform>(ItemSpawner.Instance.Prefabs); 
        CreateItems();
    }

    private void CreateItems()
    {
        int itemNumber = Mathf.Min(ITEM_NUMBER, _items.Count);
        while (itemNumber-- != 0)
        {
            int numberOfItem = Random.Range(minimumItem, maximumItem);
            int indexItemRandom = Random.Range(0, _items.Count);
            AddAndRemoveItem(numberOfItem, indexItemRandom);
        }
    }

    private void AddAndRemoveItem(int numberOfItem, int indexItemRandom)
    {
        listRandomItems.Add(_items[indexItemRandom], numberOfItem);
        _items.Remove(_items[indexItemRandom]);
    }

    public virtual bool CheckEnough()
    {
        if (listRandomItems.Count == 0) return false;
        foreach (KeyValuePair<Transform, int> key in listRandomItems)
            if (IsEnoughItems(key)) return false;
        return true;
    }

    private static bool IsEnoughItems(KeyValuePair<Transform, int> key) =>
        key.Value > MaterialManager.Instance.GetNumberMaterial(key.Key.name);

    public void SetIsUpdate(bool status) => _isUpdate = status;
    public bool IsCanUse() => _canUse;
    public float GetTimeDelay() => timeDelay;
    public float GetTimeCounter() => _timeCounter;

    private void SetTimeCounter()
    {
        if (!_canUse) return;
        (_canUse, _timeCounter) = (false, timeDelay);
        SkillManager.Instance.ChangeStatusSkills();
    }
    private void OnDisable() => EventPlayerShoote.UnSubscribe(SetTimeCounter);
}
