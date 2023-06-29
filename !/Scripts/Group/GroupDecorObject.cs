using UnityEngine;

namespace Group
{
    public class GroupDecorObject : Group
    {
        [SerializeField] protected GroupSO decorObejctSO;

        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.LoadDecorObjectSO();
        }

        protected override void Awake()
        {
            this.objectSpawner = DecorObjectSpawner.Instance.GetRandomPrefab();
            base.Awake();
        }

        protected virtual void LoadDecorObjectSO()
        {
            this.decorObejctSO ??= Resources.Load<GroupSO>("Group/" + transform.name);
            (this.maxNumber, this.minNumber) = (this.decorObejctSO.MaxOSNumber, this.decorObejctSO.MinOSNumber);
        }

        protected override void SpawnObject(Vector3 position, Quaternion rotation) =>
            DecorObjectSpawner.Instance.SpawnInRegion(this.objectSpawner, "Forest", position, rotation);
    }
}