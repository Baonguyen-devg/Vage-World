using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreatingPackage
{
    public abstract class Create : AutoMonobehaviour
    {
        protected int[] col = { 0, 0, -1, 1 };
        protected int[] row = { -1, 1, 0, 0 };

        [Header(" Density adjustment")]
        [Range(0, 100), SerializeField] protected int numberGroup;

        [SerializeField] protected MapController mapController;
        protected virtual void LoadMapController() =>
          this.mapController ??= GetComponentInParent<MapController>();

        protected override void LoadComponent() => this.LoadMapController();

        public virtual void CreateGroup() => Enumerable.Range(1, numberGroup).ToList().ForEach(_ => Group());

        protected virtual void Group()
        {
            List<Transform> listFake = this.mapController.CreateMap.landList;
            if (listFake.Count == 0) return;

            int randomPosition = Random.Range(0, listFake.Count);
            this.SpawnObject(listFake[randomPosition].position, listFake[randomPosition].rotation);
        }

        protected virtual void SpawnObject(Vector3 position, Quaternion rotation) { }
    }
}