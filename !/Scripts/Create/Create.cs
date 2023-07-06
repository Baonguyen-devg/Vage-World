using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreatingPackage
{
    [System.Serializable] public class ResourceSpawner
    {
        [SerializeField] private string nameResourceSpawner;
        public string NameResourceSpawner => this.nameResourceSpawner;
        [Range(min: 0, max: 100), SerializeField] private int number;
        public int Number => this.number;

        public ResourceSpawner(string nameResourceSpawner, int number) =>
            (this.nameResourceSpawner, this.number) = (nameResourceSpawner, number);
    }

    public abstract class Create : AutoMonobehaviour
    {
        protected int[] col = { 0, 0, -1, 1 };
        protected int[] row = { -1, 1, 0, 0 };

        [Header(header: "[ Level Manager Scriptable Object ]"), Space(height: 10)]
        [SerializeField] protected LevelManagerSO levelManagerSO = default;
        protected virtual void LoadLevelManagerSO() =>
             this.levelManagerSO = Resources.Load<LevelManagerSO>(path: "Level/" + "EasyLevel_" + GameController.Instance.Level.ToString());

        [Header(header: "[ Density adjustment ]"), Space(height: 10)]
        [SerializeField] protected List<ResourceSpawner> resourceSpawners;
        protected abstract void LoadResourceSpawners();

        [SerializeField] protected MapController mapController;
        protected virtual void LoadMapController() =>
          this.mapController ??= GetComponentInParent<MapController>();

        protected override void LoadComponent()
        {
            this.LoadMapController();
            this.LoadLevelManagerSO();
            this.LoadResourceSpawners();
        }

        public virtual void CreateGroup() => 
            Enumerable.Range(start: 0, count: this.resourceSpawners.Count)
                .ToList().ForEach(action: pointer => Group(pointer: pointer));

        protected abstract void Group(int pointer);
        protected abstract Transform SpawnObject(Vector3 position, Quaternion rotation);
    }
}