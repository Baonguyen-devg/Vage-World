using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : AutoMonobehaviour
{
    [SerializeField] protected List<Transform> listRandomMap;
    [SerializeField] protected Dictionary<Transform, int> listRandomMaterial;

    public Dictionary<Transform, int> ListRandomMaterial => this.listRandomMaterial;

    [Range(min: 2, max: 4), SerializeField] protected int levelSkill;
    [Range(min: 2, max: 20), SerializeField] protected int baseLevel;

    [SerializeField] protected float timeDelay = 5;
    public float TimeDelay => this.timeDelay;

    protected virtual void Start()
    {
        this.RandomPositionMap();
        this.RandomMaterial();
    }

    protected virtual void RandomPositionMap()
    {
        this.listRandomMap = new List<Transform>(capacity: ItemSpawner.Instance.ListPrefab.Count);
        System.Random random = new System.Random();
        this.listRandomMap = ItemSpawner.Instance.ListPrefab.OrderBy(element => random.Next()).ToList();
    }

    protected virtual void RandomMaterial()
    {
        this.listRandomMaterial = new Dictionary<Transform, int>();
        int minRandom = this.baseLevel * (this.levelSkill - 1);
        int maxRandom = this.baseLevel * (this.levelSkill + 1);

        this.CreateNumberMaterialAbout(minRandom: minRandom, maxRandom: maxRandom);
    }

    protected virtual void CreateNumberMaterialAbout(int minRandom, int maxRandom)
    {
        for (int i = 0; i <= 2; i++)
        {
            int value = Random.Range(minInclusive: minRandom, maxExclusive: maxRandom);
            int mapRadom = Random.Range(minInclusive: 0, maxExclusive: this.listRandomMap.Count);

            Transform material = this.listRandomMap[mapRadom].GetComponent<ListPrefab>().GetRandomPrefab();
            while (this.listRandomMaterial.ContainsKey(key: material))
            {
                mapRadom = Random.Range(minInclusive: 0, maxExclusive: this.listRandomMap.Count);
                material = this.listRandomMap[mapRadom].GetComponent<ListPrefab>().GetRandomPrefab();
            }
            this.listRandomMaterial.Add(key: material, value: value);
        }
    }

    public virtual bool CheckEnough()
    {
        foreach (KeyValuePair<Transform, int> key in this.listRandomMaterial)
            if (key.Value > MaterialController.Instance.GetNumberMaterial(nameMaterial: key.Key.name)) return false;
        return true;
    }
}
