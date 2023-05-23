using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listRandomMap;
    [SerializeField] protected Dictionary<Transform, int> listRandomMaterial;
    public Dictionary<Transform, int> ListRandomMaterial => this.listRandomMaterial;

    [Range(2, 4)] [SerializeField] protected int levelSkill;
    [Range(5, 25)] [SerializeField] protected int baseLevel;
    [SerializeField] protected float timeDelay = 5;
    public float TimeDelay => this.timeDelay;

    protected virtual void Start()
    {
        this.listRandomMaterial = new Dictionary<Transform, int>(3);
        this.listRandomMap = new List<Transform>(ItemSpawner.Instance.ListPrefab.Count);
        this.RandomPositionMap();
        this.RandomMaterial();
    }

    protected virtual void RandomPositionMap()
    {
        System.Random random = new System.Random();
        this.listRandomMap = ItemSpawner.Instance.ListPrefab.OrderBy(element => random.Next()).ToList();
    }

    protected virtual void RandomMaterial()
    {
        int minRandom = this.baseLevel * (this.levelSkill - 1);
        int maxRandom = this.baseLevel * (this.levelSkill + 1);
        for (int i = 0; i <= 2; i++)
        {
            int value = Random.Range(minRandom, maxRandom);
            this.listRandomMaterial.Add(this.listRandomMap[i].GetComponent<ListPrefab>().GetRandomPrefab(), value);
        }
    }

    public virtual bool CheckEnough()
    {
        foreach (KeyValuePair<Transform, int> key in this.listRandomMaterial)
            if (key.Value > MaterialController.Instance.GetNumberMaterial(key.Key.name)) return false;

        return true;
    }
}
