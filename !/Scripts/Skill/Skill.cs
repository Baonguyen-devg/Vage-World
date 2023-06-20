using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listRandomMap;
    [SerializeField] protected Dictionary<Transform, int> listRandomMaterial;
    public Dictionary<Transform, int> ListRandomMaterial => this.listRandomMaterial;

    [Range(2, 4)][SerializeField] protected int levelSkill;
    [Range(5, 25)][SerializeField] protected int baseLevel;
    [SerializeField] protected float timeDelay = 5;
    public float TimeDelay => this.timeDelay;

    protected virtual void Start()
    {
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
        this.listRandomMaterial = new Dictionary<Transform, int>();
        int minRandom = this.baseLevel * (this.levelSkill - 1);
        int maxRandom = this.baseLevel * (this.levelSkill + 1);
        for (int i = 0; i <= 2; i++)
        {
            int value = Random.Range(minRandom, maxRandom);
            int mapRan = Random.Range(0, this.listRandomMap.Count);
            Transform material = this.listRandomMap[mapRan].GetComponent<ListPrefab>().GetRandomPrefab();
            while (this.listRandomMaterial.ContainsKey(material))
            {
                mapRan = Random.Range(0, this.listRandomMap.Count);
                material = this.listRandomMap[mapRan].GetComponent<ListPrefab>().GetRandomPrefab();
            }
            this.listRandomMaterial.Add(material, value);
        }
    }

    public virtual bool CheckEnough()
    {
        foreach (KeyValuePair<Transform, int> key in this.listRandomMaterial)
            if (key.Value > MaterialController.Instance.GetNumberMaterial(key.Key.name)) return false;

        return true;
    }
}
