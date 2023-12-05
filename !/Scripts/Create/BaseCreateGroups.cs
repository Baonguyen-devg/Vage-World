using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreatingPackage
{
    public abstract class BaseCreateGroups<T> : AutoMonobehaviour where T: Group.Group
    {
        [Header("[ Scriptable Obejct ]"), Space(6)]
        [SerializeField] protected GroupSpawnSO groupSpawnSO;
        [SerializeField] protected bool isNullScriptableObject;
        [SerializeField] protected bool isLogger;

        [Header("[ Density adjustment ]"), Space(10)]
        [SerializeField] protected List<GroupSpawnSO.ObjectSpawnInfo> resourceSpawners;
        [SerializeField] protected MapController mapController;

        #region Load Component Methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            mapController = GetComponentInParent<MapController>();
            groupSpawnSO = Resources.Load<GroupSpawnSO>(GetPath());

            if (isNullScriptableObject && CheckNullScriptableObject())
            {
                if (isLogger) Debug.LogError($"Have errors when load scriptable in {name}", this);
                gameObject.SetActive(false);
                return;
            }
            Debug.Log(groupSpawnSO.GetObjectSpawns().Count);
            resourceSpawners = new List<GroupSpawnSO.ObjectSpawnInfo>(groupSpawnSO.GetObjectSpawns());
        }

        protected abstract string GetPath();
        protected virtual bool CheckNullScriptableObject() => groupSpawnSO == null;
        #endregion

        public virtual void CreateGroup()
        {
            List<Transform> lands = GetAllLandInMap();
            if (lands.Count == 0) return;

            foreach (GroupSpawnSO.ObjectSpawnInfo resource in resourceSpawners)
            for (int i = 1; i <= resource.NumberGroup; i++)
            {
                Vector3 randomPosition = GetRandomPosition(lands);
                Transform group = SpawnGroup(randomPosition, Quaternion.Euler(1, 1, 1));

                T type = group.GetComponent<T>();
                type.SetObjectSpawner(resource.ObjectName, resource.NumberObject, group.position);
            }
        }

        protected virtual Vector3 GetRandomPosition(List<Transform> lands)
        {
            Transform landRandom = lands[Random.Range(0, lands.Count)];
            return landRandom.position;
        }

        protected abstract List<Transform> GetAllLandInMap();
        protected abstract Transform SpawnGroup(Vector3 position, Quaternion rotation);
    }
}