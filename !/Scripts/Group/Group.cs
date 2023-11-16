using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public abstract class Group : AutoMonobehaviour
    {
        protected readonly int[] horizontalOffsets = { 0, 0, -1, 1 };
        protected readonly int[] verticalOffsets = { -1, 1, 0, 0 };

        [Range(0, 50)]
        [SerializeField] protected int numberObject;
        [SerializeField] protected string objectToSpawner;
        [SerializeField] protected MapController mapController;

        protected Queue<Vector2> landPositions = new Queue<Vector2>();
        protected List<int> randomizedIndices = new List<int>();
        protected int count = 0;

        #region Load Component Methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            mapController = GameObject.Find("Map").GetComponent<MapController>();
        }
        #endregion

        public virtual void SetObjectSpawner(string nameObject, int number, Vector3 startPoint)
        {
            (objectToSpawner, numberObject) = (nameObject, number);
            CreateObjectsInGroup(startPoint);
        }

        protected virtual void CreateObjectsInGroup(Vector3 startPoint)
        {
            count = 0;
            landPositions.Enqueue(startPoint);

            while (count < numberObject && landPositions.Count != 0)
                GenerateObjectsAroundPosition(landPositions.Dequeue());
        }

        protected virtual void GenerateObjectsAroundPosition(Vector3 pos)
        {
            randomizedIndices = new List<int>() { 0, 1, 2, 3 };
            Vector2 positionPoint = Vector2.zero;

            while (randomizedIndices.Count != 0 && count < numberObject)
            {
                int index = GetRandomIndex();
                int x = (int)pos.x + horizontalOffsets[index];
                int y = (int)pos.y + verticalOffsets[index];

                if (!IsGetLand(x, y)) continue;

                count = count + 1;
                (positionPoint.x, positionPoint.y) = (x, y);
                CreateObject(positionPoint);
            }
        }

        protected virtual bool IsGetLand(int x, int y)
        {
            if (mapController.CreateMap.GetLand(x, y) == null) return false;
            mapController.CreateMap.RemoveLand(x, y);
            return true;
        }

        protected virtual int GetRandomIndex()
        {
            int index = Random.Range(0, randomizedIndices.Count);
            randomizedIndices.Remove(randomizedIndices[index]);
            return index;
        }

        protected virtual void CreateObject(Vector2 positionPoint)
        {
            landPositions.Enqueue(positionPoint);
            SpawnObject(positionPoint, transform.rotation);
        }

        protected abstract void SpawnObject(Vector3 position, Quaternion rotation);
    }
}