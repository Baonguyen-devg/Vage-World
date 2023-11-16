using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupSpawn", menuName = "ScriptableObjects/GroupSpawn")]
public class GroupSpawnSO : ScriptableObject
{
    #region ObjectSpawnInfor Class
    [System.Serializable] public class ObjectSpawnInfo
    {
        [SerializeField] private string objectName;
        [SerializeField] private int numberObject;
        [SerializeField] private int numberGroup;

        public string ObjectName => objectName;
        public int NumberObject => numberObject;
        public int NumberGroup => numberGroup;
    }
    #endregion

    [SerializeField] private List<ObjectSpawnInfo> objectSpawns = new List<ObjectSpawnInfo>();
    public List<ObjectSpawnInfo> GetObjectSpawns() => objectSpawns;

    public ObjectSpawnInfo GetSOByName(string name) =>
       objectSpawns.FirstOrDefault(objectSpawnInfo => objectSpawnInfo.ObjectName.Equals(name));
}
