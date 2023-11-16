using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private int health = 1000;
    [SerializeField] private float mana = 1000;
    [SerializeField] private int dame = 100;
    [SerializeField] private float speed = 0.01f;

    public int GetHealth() => health;
    public float GetMana() => mana;
    public int GetDame() => dame;
    public float GetSpeed() => speed;
}

