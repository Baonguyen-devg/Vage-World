using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomDirection : AutoMonobehaviour
{
    //This value describe distance betweens 2 directions = 10
    private const int rate_Part_Crirle = 2;
    private const string persudo_Messenge_Random = "VageWorld"; //Seed for random
    private const int maximum_Distance_Point = 2;
    private const int radian_Followed = 80;
    private const float time_Delay_Create = 0.2f;

    [SerializeField] private List<Vector2> avoidDirections;
    [SerializeField] private List<int> validDirections;
    [SerializeField] private Transform targetFollow = null;

    public Transform TargetFollow => this.targetFollow;
    public virtual void SetTargetFollow(Transform target) => 
        this.targetFollow = target;

    [SerializeField] private List<Vector2> directions;
    [SerializeField] private float timeCount = 0;
    [SerializeField] private bool stopCreate = false;

    [SerializeField] private EnemyController controller;
    private void LoadController() =>
        this.controller ??= transform.parent?.GetComponent<EnemyController>();

    protected override void LoadComponent() => this.LoadController();

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        this.directions = new List<Vector2>();
        this.validDirections = new List<int>();
        this.avoidDirections = new List<Vector2>();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        this.targetFollow = GameObject.Find("Player").transform;
        int numberDirection = (int)360 / rate_Part_Crirle;
        for (int i = 0; i < numberDirection; i++)
            this.directions.Add(this.GetPostionFromAngle(2f * Mathf.PI / (float)numberDirection * i));
    }

    private void Update()
    {
        if (this.stopCreate == true) return;
        if (this.timeCount <= time_Delay_Create)
        {
            this.timeCount += Time.deltaTime;
            return;
        }

        this.timeCount = 0;
        this.CheckAndLoadNewDirections();
    }

    //Calculate Method For Random Direction 
    private float GetRadian(float angle) => 
        angle * Mathf.Deg2Rad;

    private float GetAngle(float radian) => 
        radian * Mathf.Rad2Deg;

    private float CalculateAngleDiscrepancy(Vector3 pos1, float radian)
    {
        float angleBetween = Mathf.Abs(Mathf.Repeat(this.GetAngle(this.GetAngleFromPosition(pos1)), 360f) - radian);
        return Mathf.Min(angleBetween, 360 - angleBetween);
    }

    private float GetAngleFromPosition(Vector2 postition) =>
        Mathf.Atan2(postition.y - transform.parent.position.y, postition.x - transform.parent.position.x);

    private Vector2 GetPostionFromAngle(float radian) =>
        new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * maximum_Distance_Point;

    private int GetPersudoRandom(string messenge)
    {
        if (this.validDirections.Count == 0) return 0;
        messenge = System.DateTime.Now.ToString() + messenge + transform.parent.GetInstanceID();

        System.Random psuedo = new System.Random(messenge.GetHashCode());
        return psuedo.Next(this.validDirections.Count);
    }

    private IEnumerator SetStopCreate(bool status)
    {
        yield return new WaitForSeconds(0f);
        this.stopCreate = status;
    }

    public virtual void AddAnAvoidDirection(Vector3 direction) => 
        this.avoidDirections.Add(direction);

    private bool OutsideTargetFollow(float radian) =>
        (this.CalculateAngleDiscrepancy(this.targetFollow.position, radian) <= radian_Followed);

    public virtual void RemoveAnAvoidDirection(Vector3 coordinate)
    {
        int index = this.avoidDirections.FindIndex(x => x.Equals(coordinate));
        if (index != -1) this.avoidDirections.RemoveAt(index);
    }

    private void CheckAndLoadNewDirections()
    {
        if (this.targetFollow == null) return;
        this.validDirections.Clear();

        for (int i = 0; i < this.directions.Count; i++)
            if (this.OutsideTargetFollow(i * rate_Part_Crirle))
                this.validDirections.Add(i);

        this.DodgeAvoidDirection();
        if (this.validDirections.Count <= 2)
        {
            float angle = Mathf.Repeat(this.GetAngle(this.GetAngleFromPosition(this.targetFollow.position)), 360f) + Random.Range(90, 180);
            if (angle >= 360) angle = angle % 360;
            this.stopCreate = true;
            this.validDirections.Add((int)angle / rate_Part_Crirle);
            StartCoroutine(this.SetStopCreate(false));
        }
        this.CreateRandomlyDirection();
    }

    private void DodgeAvoidDirection()
    {
        List<int> removeValidDirections = new List<int>();

        foreach (Vector3 avoid in this.avoidDirections)
            foreach (int valid in this.validDirections)
                if (CalculateAngleDiscrepancy(avoid, valid * rate_Part_Crirle) <= 40)
                    removeValidDirections.Add(valid);

        foreach (int indexRemoved in removeValidDirections)
            this.validDirections.Remove(indexRemoved);
    }

    private void CreateRandomlyDirection() =>
        this.DrawLineDirections(this.validDirections[this.GetPersudoRandom(persudo_Messenge_Random)]);

    private void DrawLineDirections(int validDirection)
    {
        for (int i = 0; i < this.validDirections.Count; i++)
        {
            Color colorDrawLine = (validDirection == this.validDirections[i]) ? Color.white : Color.gray;
            Vector3 pos = transform.parent.position + new Vector3(this.directions[this.validDirections[i]].x, this.directions[this.validDirections[i]].y, 0);
            Debug.DrawLine(transform.parent.position, pos, colorDrawLine, 0.01f);
        }

        Vector3 directionNormalize = new Vector3(this.directions[validDirection].x, this.directions[validDirection].y, 0);
        directionNormalize.Normalize();
        this.controller.Movement.SetDirectionFollow(directionNormalize);
    }

}
