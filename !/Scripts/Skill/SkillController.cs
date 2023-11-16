using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SkillController : BaseLoadLevelManagerSO
{
    [SerializeField] protected List<Transform> items ;
    [SerializeField] public Dictionary<Transform, int> listRandomItems
       = new Dictionary<Transform, int>();

    [SerializeField] protected int levelSkill = 1;
    [SerializeField] protected int baseLevel = 1;
    [SerializeField] protected int itemNumber = 3;

    [SerializeField] protected float timeDelay = 55;
    [SerializeField] protected float timeCounter = 0;
    [SerializeField] protected bool canUse;

    protected override void Start()
    {
        base.Start();
        var skillSO = levelManagerSO?.GetSkillSOByName(transform.name);
        (levelSkill, baseLevel, timeDelay) = (skillSO.LevelSkill, skillSO.BaseLevel, skillSO.TimeDelay);

        Attack.PlayerShootingAttack.ShootePlayerEvent += SetTimeCounter;
        Observable.EveryUpdate().Subscribe(_ => CountDown()).AddTo(this);
    }

    protected virtual void CountDown()
    {
        if (timeCounter >= 0) timeCounter = timeCounter - Time.deltaTime;
        canUse = (timeCounter < 0);
    }

    protected override IEnumerator LoadWaitForShortTime()
    {
        yield return StartCoroutine(base.LoadWaitForShortTime());
        items = ItemSpawner.Instance.Prefabs;
        CreateItems();
    }

    protected virtual void CreateItems()
    {
        int minRandom = baseLevel * (levelSkill - 1);
        int maxRandom = baseLevel * (levelSkill + 1);

        List<Transform> randoms = items;
        for (int i = 0; i < Mathf.Min(itemNumber, items.Count); i++)
        {
            int value = Random.Range(minRandom, maxRandom);
            int itemRandom = Random.Range(0, randoms.Count);

            listRandomItems.Add(items[itemRandom], value);
            randoms.Remove(randoms[itemRandom]);
        }
    }

    public virtual bool CheckEnough()
    {
        if (listRandomItems.Count == 0) return false;
        foreach (KeyValuePair<Transform, int> key in listRandomItems)
            if (key.Value > MaterialManager.Instance.GetNumberMaterial(key.Key.name)) return false;
        return true;
    }

    public bool IsCanUse() => canUse;
    public float GetTimeDelay() => timeDelay;
    public float GetTimeCounter() => timeCounter;

    protected virtual void OnDisable() => Attack.PlayerShootingAttack.ShootePlayerEvent -= SetTimeCounter;
    protected virtual void SetTimeCounter() => timeCounter = timeDelay;
}
