using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionRandomlyMovement : AutoMonobehaviour
{
    //This value describe distance betweens 2 directions = 10
    private const int rate_Part_Crirle = 10;
    private const string persudo_Messenge_Random = "VageWorld"; //Seed for random
    private const int maximum_Distance_Point = 2;
    private const int radian_Followed = 60;

    [SerializeField] private List<int> validDirections;
    [SerializeField] private Transform targetFollow = null;
    [SerializeField] private List<Vector2> directions;
    [SerializeField] private TestEnemyController controller;

    private void LoadController() =>
        this.controller ??= transform.parent?.GetComponent<TestEnemyController>();

    private void Update() => this.CheckAndLoadNewDirections();

    public DirectionRandomlyMovement() { }

    protected override void LoadComponent()
    {
        this.LoadController();
        this.targetFollow = GameObject.Find("Player").transform;
        int numberDirection = (int)360 / rate_Part_Crirle;
        this.directions = new List<Vector2>();
        this.validDirections = new List<int>(numberDirection);

        //Using to add directions into list follow rate_Part_Crirle
        for (int i = 0; i < numberDirection; i++)
            this.directions.Add(this.GetPostionFromAngle(2f * Mathf.PI / (float)numberDirection * i));
    }

    private float GetRadian(float angle) => angle * Mathf.Deg2Rad;
    private float GetAngle(float radian) => radian * Mathf.Rad2Deg;

    private float GetAngleFromPosition(Vector2 postition) =>
        Mathf.Atan2(postition.y - transform.parent.position.y, postition.x - transform.parent.position.x);

    private Vector2 GetPostionFromAngle(float radian) =>
        new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * maximum_Distance_Point;

    private void CheckAndLoadNewDirections()
    {
        if (this.targetFollow == null) return;
        this.validDirections.Clear();

        for (int i = 0; i < this.directions.Count; i++)
            if (this.OutsideTargetFollow(i * rate_Part_Crirle))
                this.validDirections.Add(i);

        this.CreateRandomlyDirection();
    }

    private void CreateRandomlyDirection() =>
        this.DrawLineDirections(this.validDirections[this.GetPersudoRandom(persudo_Messenge_Random)]);

    private void DrawLineDirections(int validDirection)
    {
        for (int i = 0; i < this.validDirections.Count; i++)
        {
            Color colorDrawLine = (validDirection == this.validDirections[i]) ? Color.white : Color.black;
            Vector3 pos = transform.parent.position + new Vector3(this.directions[this.validDirections[i]].x, this.directions[this.validDirections[i]].y, 0);
            Debug.DrawLine(transform.parent.position, pos, colorDrawLine);
        }

        Vector3 directionNormalize = new Vector3(this.directions[validDirection].x, this.directions[validDirection].y, 0);
        directionNormalize.Normalize();
        this.controller.Movement.SetDirectionFollow(directionNormalize);
    }

    private int GetPersudoRandom(string messenge)
    {
        if (this.validDirections.Count == 0) return 0;
        messenge = System.DateTime.Now.ToString() + messenge + transform.parent.ToString();

        System.Random psuedo = new System.Random(messenge.GetHashCode());
        return psuedo.Next(this.validDirections.Count);
    }

    private bool OutsideTargetFollow(float radian) =>
        (this.CalculateAngleDiscrepancy(this.targetFollow.position, radian) <= radian_Followed);

    private float CalculateAngleDiscrepancy(Vector3 pos1, float radian)
    {
        float angleBetween = Mathf.Abs(Mathf.Repeat(this.GetAngle(this.GetAngleFromPosition(pos1)), 360f) - radian);
        return Mathf.Min(angleBetween, 360 - angleBetween);
    }
}
