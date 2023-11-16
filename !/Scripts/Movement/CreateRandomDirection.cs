using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomDirection : AutoMonobehaviour
{
    //This value describe distance betweens 2 directions = 10
    private const int rate_Part_Crirle = 2;
    private const string persudo_Messenge_Random = "VageWorld"; //Seed for random
    private const int maximum_Distance_Point = 2;
    private const int radian_Followed = 45;
    private const float time_Delay_Create = 0.5f;

    [SerializeField] private List<Vector2> avoidDirections;
    [SerializeField] private List<int> validDirections;
    [SerializeField] private Transform targetFollow = null;

    public Transform TargetFollow => targetFollow;
    public virtual void SetTargetFollow(Transform target) => 
        targetFollow = target;

    [SerializeField] private List<Vector2> directions;
    [SerializeField] private float timeCount = 0;
    [SerializeField] private bool stopCreate = false;

    [SerializeField] private EnemyController controller;
    private void LoadController() =>
        controller ??= transform.parent?.GetComponent<EnemyController>();

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => LoadController();

    protected override void LoadComponentInAwakeBefore()
    {
        base.LoadComponentInAwakeBefore();
        directions = new List<Vector2>();
        validDirections = new List<int>();
        avoidDirections = new List<Vector2>();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        targetFollow = GameObject.Find("Player").transform;
        int numberDirection = (int)360 / rate_Part_Crirle;
        for (int i = 0; i < numberDirection; i++)
            directions.Add(GetPostionFromAngle(2f * Mathf.PI / (float)numberDirection * i));
    }

    private void Update()
    {
        if (stopCreate == true) return;
        if (timeCount <= time_Delay_Create)
        {
            timeCount += Time.deltaTime;
            return;
        }

        timeCount = 0;
        CheckAndLoadNewDirections();
    }

    private float GetAngle(float radian) => 
        radian * Mathf.Rad2Deg;

    private float CalculateAngleDiscrepancy(Vector3 pos1, float radian)
    {
        float angleBetween = Mathf.Abs(Mathf.Repeat(GetAngle(GetAngleFromPosition(pos1)), 360f) - radian);
        return Mathf.Min(angleBetween, 360 - angleBetween);
    }

    private float GetAngleFromPosition(Vector2 postition) =>
        Mathf.Atan2(postition.y - transform.parent.position.y, postition.x - transform.parent.position.x);

    private Vector2 GetPostionFromAngle(float radian) =>
        new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * maximum_Distance_Point;

    private int GetPersudoRandom(string messenge)
    {
        if (validDirections.Count == 0) return 0;
        messenge = System.DateTime.Now.ToString() + messenge + transform.parent.GetInstanceID();

        System.Random psuedo = new System.Random(messenge.GetHashCode());
        return psuedo.Next(validDirections.Count);
    }

    private IEnumerator SetStopCreate(bool status)
    {
        yield return new WaitForSeconds(0f);
        stopCreate = status;
    }

    public virtual void AddAnAvoidDirection(Vector3 direction) => 
        avoidDirections.Add(direction);

    private bool OutsideTargetFollow(float radian) =>
        (CalculateAngleDiscrepancy(targetFollow.position, radian) <= radian_Followed);

    private void CheckAndLoadNewDirections()
    {
        if (targetFollow == null) return;
        validDirections.Clear();

        for (int i = 0; i < directions.Count; i++)
            if (OutsideTargetFollow(i * rate_Part_Crirle))
                validDirections.Add(i);

        DodgeAvoidDirection();
        if (validDirections.Count <= 2)
        {
            float angle = Mathf.Repeat(GetAngle(GetAngleFromPosition(targetFollow.position)), 360f) + Random.Range(90, 180);
            if (angle >= 360) angle = angle % 360;
            stopCreate = true;
            validDirections.Add((int)angle / rate_Part_Crirle);
            StartCoroutine(SetStopCreate(false));
        }
        CreateRandomlyDirection();
    }

    private void DodgeAvoidDirection()
    {
        List<int> removeValidDirections = new List<int>();

        foreach (Vector3 avoid in avoidDirections)
            foreach (int valid in validDirections)
                if (CalculateAngleDiscrepancy(avoid, valid * rate_Part_Crirle) <= 40)
                    removeValidDirections.Add(valid);

        foreach (int indexRemoved in removeValidDirections)
            validDirections.Remove(indexRemoved);
    }

    private void CreateRandomlyDirection() =>
        DrawLineDirections(validDirections[GetPersudoRandom(persudo_Messenge_Random)]);

    private void DrawLineDirections(int validDirection)
    {
        for (int i = 0; i < validDirections.Count; i++)
        {
            Color colorDrawLine = (validDirection == validDirections[i]) ? Color.white : Color.gray;
            Vector3 pos = transform.parent.position + new Vector3(directions[validDirections[i]].x, directions[validDirections[i]].y, 0);
            Debug.DrawLine(transform.parent.position, pos, colorDrawLine, 0.01f);
        }

        Vector3 directionNormalize = new Vector3(directions[validDirection].x, directions[validDirection].y, 0);
        directionNormalize.Normalize();
        controller.Movement.SetDirectionFollow(directionNormalize);
    }

}
