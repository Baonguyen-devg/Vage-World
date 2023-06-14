using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager")]
public class LevelManagerSO : ScriptableObject
{
    [Header("[ SET UP MAP] ")]
    [Range(50, 200)] [SerializeField] private int height;
    [Range(50, 200)] [SerializeField] private int width;
    [Range(0, 10)] [SerializeField] private int smooth;
    [Range(0, 100)] [SerializeField] private int randomFillPercent;
    [Range(0, 10)] [SerializeField] private float rateDecorObject;
    [Range(0, 10)] [SerializeField] private int rateChangeColor;

    [Space(3), Header("[ SET UP SKILL ]"), Space(3)]
    [Range(2, 4)] [SerializeField] private int levelSkill;
    [Range(5, 25)] [SerializeField] private int baseLevel;
    [SerializeField] private int rateSkill1;
    [SerializeField] private int rateSkill2;
    [SerializeField] private int rateSkill3;

    [Space(3), Header("[ SET UP ITEMS ]"), Space(3)]
    [SerializeField] private int distanceBetween;
    [SerializeField] private int number;

    [Space(3), Header("[ SET UP TIMELINE ]"), Space(3)]
    [SerializeField] private int timeAppearBoss;

    [Space(3), Header("[ SET UP BOSS ]"), Space(3)]
    [SerializeField] private int dame;
    [SerializeField] private int health;
    [SerializeField] private double speed;

    //Encapsulations Map
    public int Height { get => height; }
    public int Width { get => width; }
    public int Smooth { get => smooth; }
    public float RateDecorObject { get => this.rateDecorObject; }
    public int RandomFillPercent { get => randomFillPercent; }
    public int RateChangeColor { get => rateChangeColor; }

    //Encapsulations Skill
    public int LevelSkill { get => levelSkill; }
    public int BaseLevel { get => baseLevel; }
    public int RateSkill1 { get => rateSkill1; }
    public int RateSkill2 { get => rateSkill2; }
    public int RateSkill3 { get => rateSkill3; }

    //Encapsulations Items
    public int DistanceBetween { get => distanceBetween; }
    public int Number { get => number; }

    //Encapsulations Timeline
    public int TimeAppearBoss { get => timeAppearBoss; }

    //Encapsulations Boss
    public int Dame { get => dame; }
    public int Health { get => health; }
    public double Speed { get => speed; }
}
