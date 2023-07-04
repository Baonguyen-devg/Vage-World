using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : AutoMonobehaviour
{
    protected const float default_Time_Delay = 5;
    protected const int default_Level_Skill = 1;
    protected const int default_Base_Level = 1;

    [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
    [SerializeField] protected LevelManagerSO levelManagerSO = default;
    protected virtual void LoadLevelManagerSO() =>
         this.levelManagerSO ??= Resources.Load<LevelManagerSO>(path: "Level/EasyLevel");

    [SerializeField] protected List<Transform> listRandomMap;
    [SerializeField] protected Dictionary<Transform, int> listRandomMaterial;

    public Dictionary<Transform, int> ListRandomMaterial => this.listRandomMaterial;

    [SerializeField] protected int levelSkill = default_Level_Skill;
    protected virtual void LoadLevelSkill() =>
        this.levelSkill = (int)this.levelManagerSO?.GetSkillSOByName(transform.name).LevelSkill;

    [SerializeField] protected int baseLevel = default_Base_Level;
    protected virtual void LoadBaseLevel() =>
        this.baseLevel = (int)this.levelManagerSO?.GetSkillSOByName(transform.name).BaseLevel;

    [SerializeField] protected float timeDelay = default_Time_Delay;
    public float TimeDelay => this.timeDelay;
    protected virtual void LoadTimeDelay() =>
        this.timeDelay = (float)this.levelManagerSO?.GetSkillSOByName(transform.name).TimeDelay;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLevelManagerSO();
        this.LoadLevelSkill();
        this.LoadBaseLevel();
        this.LoadTimeDelay();
    }

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
