using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Group", menuName = "ScriptableObjects/Group")]
public class GroupSO : ScriptableObject
{
    [SerializeField] protected int maxOSNumber = 2;
    [SerializeField] protected int minOSNumber = 1;

    public int MaxOSNumber => this.maxOSNumber;
    public int MinOSNumber => this.minOSNumber;
}
