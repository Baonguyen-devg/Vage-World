using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager")]
public class LevelManagerSO : ScriptableObject
{
    [System.Serializable] public class EnemySO
    {
        [Header(header: "Name Enemy: "), SerializeField] private string name;
        [HideInInspector] public string Name => this.name;

        [Space(height: 3), Header(header: "[ Set Up Stats ] "), Space(height: 3)] //STATS
        //Maximum enemy's health is about 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int maximumHealth;
        [HideInInspector] public int MaximumHealth => this.maximumHealth;

        //Maximum enemy's dame is about to 50 to 30000 (boss)
        [Range(min: 0, max: 100), SerializeField] private int dame;
        [HideInInspector] public int Dame => this.dame;

        //Maximum enemy's speed is about to 50 to 30000 (boss)
        [Range(min: 0.01f, max: 1), SerializeField] private float speed;
        [HideInInspector] public float Speed => this.speed;

        [Space(height: 3), Header(header: "[ Set Up Attack ] "), Space(height: 3)] //ATTACK
                                                                                   //Maximum enemy's distance can attack is about to 50 to 30000 (boss)
        [Range(min: 0, max: 10), SerializeField] private float distanceAttack;
        [HideInInspector] public float DistanceAttack => this.distanceAttack;

        //Maximum enemy's attack delay is about to 50 to 30000 (boss)
        [Range(min: 0, max: 10), SerializeField] private float attackDelay;
        [HideInInspector] public float AttackDelay => this.attackDelay;

        [Space(height: 3), Header(header: "[ Set Up Creating ] "), Space(height: 3)] //CREATING
        //Maximum enemy's numberObject is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberObject;
        [HideInInspector] public int NumberObject => this.numberObject;

        //Maximum enemy's numberGroup is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberGroup;
        [HideInInspector] public int NumberGroup => this.numberGroup;

    }

    [System.Serializable] public class ItemSO 
    {
        [Header(header: "Name Item: "), SerializeField] private string name;
        [HideInInspector] public string Name => this.name;

        [Space(height: 3), Header(header: "[ Set Up Creating ] "), Space(height: 3)] //CREATING
        //Maximum enemy's numberObject is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberObject;
        [HideInInspector] public int NumberObject => this.numberObject;

        //Maximum enemy's numberGroup is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberGroup;
        [HideInInspector] public int NumberGroup => this.numberGroup;
    }

    [System.Serializable] public class DecorSO
    {
        [Header(header: "Name Decor Object: "), SerializeField] private string name;
        [HideInInspector] public string Name => this.name;

        [Space(height: 3), Header(header: "[ Set Up Creating ] "), Space(height: 3)] //CREATING
        //Maximum enemy's numberObject is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberObject;
        [HideInInspector] public int NumberObject => this.numberObject;

        //Maximum enemy's numberGroup is about to 0 to 50 (boss)
        [Range(min: 0, max: 50), SerializeField] protected int numberGroup;
        [HideInInspector] public int NumberGroup => this.numberGroup;
    }


    [Space(height: 3), Header(header: "[ SET UP MAP] ")]
    [Range(min: 50, max: 200), SerializeField] private int height;
    [HideInInspector] public int Height => this.height;
    [Range(min: 50, max: 200), SerializeField] private int width;
    [HideInInspector] public int Width => this.width;
    [Range(min: 0, max: 10), SerializeField] private int smooth;
    [HideInInspector] public int Smooth => smooth;
    [Range(min: 0, max: 100), SerializeField] private int randomFillPercent;
    [HideInInspector] public int RandomFillPercent => randomFillPercent;

    [Space(height: 3), Header(header: "[ SET UP SKILL ]"), Space(height: 3)]
    [Range(min: 2, max: 4), SerializeField] private int levelSkill;
    [HideInInspector] public int LevelSkill => levelSkill;
    [Range(min: 5, max: 25), SerializeField] private int baseLevel;
    [HideInInspector] public int BaseLevel => baseLevel;

    [Space(height: 3), Header(header: "[ SET UP RATE OF SKILLs ]"), Space(height: 3)]
    [Range(min: 2, max: 5), SerializeField] private int rateSkill1;
    [HideInInspector] public int RateSkill1 => rateSkill1;
    [Range(min: 2, max: 5), SerializeField] private int rateSkill2;
    [HideInInspector] public int RateSkill2 => rateSkill2;
    [Range(min: 2, max: 5), SerializeField] private int rateSkill3;
    [HideInInspector] public int RateSkill3 => rateSkill3;

    [Space(3), Header("[ SET UP TIMELINE ]"), Space(3)]
    [SerializeField] private int timeAppearBoss;
    [HideInInspector] public int TimeAppearBoss => timeAppearBoss;

    [Space(3), Header("[ SET UP ENEMY ]"), Space(3)]
    [SerializeField] private List<EnemySO> enemies = new List<EnemySO>();
    [HideInInspector] public List<EnemySO> Enemies => this.enemies;

    [Space(3), Header("[ SET UP ITEM ]"), Space(3)]
    [SerializeField] private List<ItemSO> items = new List<ItemSO>();
    [HideInInspector] public List<ItemSO> Items => this.items;

    [Space(3), Header("[ SET UP DECOR OBJECT ]"), Space(3)]
    [SerializeField] private List<DecorSO> decorObjects = new List<DecorSO>();
    [HideInInspector] public List<DecorSO> DecorObjects => this.decorObjects;

    public EnemySO GetEnemySOByName(string name) =>
       enemies.FirstOrDefault(enemySO => enemySO.Name.Equals(value: name));

    public ItemSO GetItemSOByName(string name) =>
       items.FirstOrDefault(itemSO => itemSO.Name.Equals(value: name));

    public DecorSO GetDecorSOByName(string name) =>
       decorObjects.FirstOrDefault(decorSO => decorSO.Name.Equals(value: name));
}
