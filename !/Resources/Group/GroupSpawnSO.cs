using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupSpawn", menuName = "ScriptableObjects/GroupSpawn")]
public class GroupSpawnSO : ScriptableObject
{
    #region ObjectSpawnInfor Class
    [System.Serializable] public class ObjectSpawnInfo
    {
        [SerializeField] private string _objectName;
        [SerializeField] private int _numberObject;
        [SerializeField] private int _numberGroup;

        public string ObjectName => _objectName;
        public int NumberObject => _numberObject;
        public int NumberGroup => _numberGroup;
    }
    #endregion

    [SerializeField] 
    private List<ObjectSpawnInfo> _objectSpawns = new List<ObjectSpawnInfo>();

    public ObjectSpawnInfo GetSOByName(string name) =>
       _objectSpawns.FirstOrDefault(objectSpawnInfo => objectSpawnInfo.ObjectName.Equals(name));

    public List<ObjectSpawnInfo> GetObjectSpawns() => _objectSpawns;
}
