using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreatingPackage
{
    [System.Serializable]
    public class ResourceSpawner
    {
        [SerializeField] private string nameResourceSpawner;
        public string NameResourceSpawner => this.nameResourceSpawner;
        [Range(min: 0, max: 100), SerializeField] private int number;
        public int Number => this.number;
    }

    public abstract class Create : AutoMonobehaviour
    {
        protected int[] col = { 0, 0, -1, 1 };
        protected int[] row = { -1, 1, 0, 0 };

        [Header(header: " Density adjustment")]
        [SerializeField] protected List<ResourceSpawner> resourceSpawners;

        [SerializeField] protected MapController mapController;
        protected virtual void LoadMapController() =>
          this.mapController ??= GetComponentInParent<MapController>();

        protected override void LoadComponent() => this.LoadMapController();

        public virtual void CreateGroup() => 
            Enumerable.Range(start: 0, count: this.resourceSpawners.Count)
                .ToList().ForEach(action: _ => Group(_));

        protected abstract void Group(int pointer);
        protected abstract Transform SpawnObject(Vector3 position, Quaternion rotation);
    }
}