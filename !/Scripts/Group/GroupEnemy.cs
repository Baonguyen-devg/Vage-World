using UnityEngine;

namespace Group
{
    public class GroupEnemy : Group
    {
        [SerializeField] protected GroupSO EnemySO;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadEnemySO();
        }

        protected override void Awake()
        {
            this.objectSpawner = EnemySpawner.Instance.GetRandomPrefab();
            base.Awake();
        }

        protected virtual void LoadEnemySO()
        {
            if (this.EnemySO != null) return;
            string resPath = "Group/" + transform.name;
            this.EnemySO = Resources.Load<GroupSO>(resPath);
            this.maxNumber = this.EnemySO.MaxOSNumber;
            this.minNumber = this.EnemySO.MinOSNumber;
            Debug.LogWarning(transform.name + ": Load EnemyStoneSO" + resPath, gameObject);
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation)
        {
            Transform enemy = EnemySpawner.Instance.SpawnInRegion(this.objectSpawner, "Forest", position, rotation);
            transform.parent.GetComponent<PointSpawnEnemy>().Add(enemy);
        }

    }
}