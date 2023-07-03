using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager")]
public class LevelManagerSO : ScriptableObject
{
    [System.Serializable] public class EnemyOS
    {
        [Space(height: 3), Header(header: "[ Set Up Stats ] "), Space(height: 3)] //STATS
        //Maximum enemy's health is about 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int health;
        [HideInInspector] public int Health => this.health; 

        //Maximum enemy's dame is about to 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int dame;
        [HideInInspector] public int Dame => this.dame;

        //Maximum enemy's speed is about to 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int speed;
        [HideInInspector] public int Speed => this.speed;

        [Space(height: 3), Header(header: "[ Set Up Attack ] "), Space(height: 3)] //ATTACK
         //Maximum enemy's distance can attack is about to 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int distanceAttack;
        [HideInInspector] public int DistanceAttack => this.distanceAttack;

        //Maximum enemy's attack delay is about to 50 to 30000 (boss)
        [Range(min: 50, max: 30000), SerializeField] private int attackDelay;
        [HideInInspector] public int AttackDelay => this.attackDelay;

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

    [Space(height: 3), Header(header: "[ SMOOTH AND FILLP PERCENT ]")]
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

    [Space(3), Header("[ SET UP ITEMS ]"), Space(3)]
    [SerializeField] private int distanceBetween;
    [SerializeField] private int number;

    [Space(3), Header("[ SET UP TIMELINE ]"), Space(3)]
    [SerializeField] private int timeAppearBoss;
    [HideInInspector] public int TimeAppearBoss => timeAppearBoss;

    [Space(3), Header("[ SET UP ENEMY ]"), Space(3)]
    [SerializeField, Space(height: 3)] private EnemyOS boss = new EnemyOS();
    [HideInInspector] public EnemyOS Boss => this.boss;
    [SerializeField, Space(height: 3)] private EnemyOS skeleton = new EnemyOS();
    [HideInInspector] public EnemyOS Skeleton => this.skeleton;
    [SerializeField, Space(height: 3)] private EnemyOS dragonFly = new EnemyOS();
    [HideInInspector] public EnemyOS DragonFly => this.dragonFly;
}
