using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private int _health = 1000;
    [SerializeField] private float _mana = 1000;
    [SerializeField] private int _dame = 100;
    [SerializeField] private float _speed = 0.01f;

    public int GetHealth() => _health;
    public float GetMana() => _mana;
    public int GetDame() => _dame;
    public float GetSpeed() => _speed;
}

