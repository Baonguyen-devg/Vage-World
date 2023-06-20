using System.Collections.Generic;
using UnityEngine;

public class CreateMapTest : AutoMonobehaviour
{
    [SerializeField] protected int heightMap = 50;
    [SerializeField] protected int widthMap = 50;
    [SerializeField] protected int[,] titles;
    [SerializeField] protected string seed;

    protected int[] col = { 0, 1, -1, 0, 0, 1, 1, -1, -1 };
    protected int[] row = { -1, 0, 0, 1, 0, -1, 1, 1, -1 };
    [SerializeField] protected Transform land;
    [SerializeField] protected Transform sea;
    [SerializeField] protected int number;
    [SerializeField] protected float posPaX, posPaY;
    [SerializeField] protected string nameRegion;
    protected Queue<Vector2> queue;
    [SerializeField] protected List<int[]> listRandoms;
    protected int[] listRandom;
    protected bool[] visDirec;

    [Range(0, 100)]
    [SerializeField] protected int randomFillPercent;
    [Range(0, 10)]
    [SerializeField] protected int smoothPercent;

    protected override void Awake()
    {
        base.Awake();
        this.listRandom = new int[10];
        this.listRandoms = new List<int[]>();
        this.visDirec = new bool[10];
        this.queue = new Queue<Vector2>();
        this.number = (this.widthMap * this.heightMap) * randomFillPercent / 100;
    }

    protected virtual void Start()
    {
        this.CreateDirectionRandom(1);
        this.CreateBitRandom();
        this.SmoothMap();
        this.CreateMapRandom();
    }

    protected virtual void CreateDirectionRandom(int id)
    {
        if (id == 11)
        {
            this.listRandoms.Add(this.listRandom);
            return;
        }

        for (int i = 0; i <= 9; i++)
        {
            if (this.visDirec[i] == true) continue;

            this.visDirec[i] = true;
            this.listRandom[id - 1] = i;
            this.CreateDirectionRandom(id + 1);
            this.listRandom[id - 1] = i;
            this.visDirec[i] = false;
        }
    }

    protected virtual void CreateBitRandom()
    {
        this.seed = System.DateTime.Now.ToString() + this.seed;
        this.titles = new int[this.widthMap + 2, this.heightMap + 2];
        System.Random psuedo = new System.Random(this.seed.GetHashCode());

        int x = this.widthMap / 2, y = this.heightMap / 2, count = 0;
        this.queue.Enqueue(new Vector2(x, y));
        while (count != this.number && this.queue.Count != 0)
        {
            Vector2 key = this.queue.Dequeue();
            int z = (int)key.x;
            int t = (int)key.y;

            int keyRandom = -1;
            int keyRandomList = psuedo.Next(0, 1000) % 120;

            for (int id = 0; id < 10; id++)
            {
                int i = this.listRandoms[keyRandomList][id];
                if (z + col[i] < 1 || t + row[i] < 1 || z + col[i] > this.widthMap || t + row[i] > this.heightMap) continue;
                if (this.titles[z + col[i], t + row[i]] != 1)
                {
                    keyRandom = i;
                    break;
                }
            }
            if (keyRandom == -1) continue;
            int X = z + col[keyRandom], Y = t + row[keyRandom];
            this.queue.Enqueue(new Vector2(X, Y));

            this.titles[X, Y] = 1;
            count = count + 1;
        }
    }

    protected virtual void CreateMapRandom()
    {
        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                Vector3 pos = new Vector3(i + this.posPaX - this.widthMap / 2, j + this.posPaY - this.heightMap / 2, 0);
                Quaternion rot = transform.rotation;

                Transform Land = null;
                if (this.titles[i, j] == 1) Land = Instantiate(this.land);
                if (this.titles[i, j] == 0) Land = Instantiate(this.sea);

                Land.SetPositionAndRotation(pos, rot);
            }
    }

    protected virtual void SmoothMap()
    {
        for (int i = 0; i < this.smoothPercent; i++)
            this.Smooth();
    }

    protected virtual void Smooth()
    {
        for (int i = 1; i <= this.widthMap; i++)
            for (int j = 1; j <= this.heightMap; j++)
            {
                if (this.titles[i, j] == 1) continue;
                int numberLandAround = this.LandAround(i, j);

                if (numberLandAround > 4) this.titles[i, j] = 1;
            }
    }

    protected virtual int LandAround(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
                if (i < 1 || j < 1 || i > this.widthMap || j > this.heightMap) count = count + 1;
                else if (i != x || j != y) count = count + this.titles[i, j];
        return count;
    }
}
