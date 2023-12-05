using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CreateRandomDirection : AutoMonobehaviour
{
    private readonly int RATE_PART_CICRLE = 2;
    private readonly string PERSUDO_MESSENGE_RANDOM = "VageWorld"; 
    private readonly int MAXIMUM_DISTANCE_POINT = 2;
    private readonly int RADIAN_FOLLOWED = 45;
    private readonly float TIME_DELAY_CREATE = 0.5f;

    [SerializeField] private Transform _targetFollow;
    [SerializeField] private EnemyController _controller;
    [SerializeField] private float _timeCount;
    [SerializeField] private bool _stopCreate;

    private List<Vector2> _directions = new List<Vector2>();
    private List<Vector2> _avoidDirections = new List<Vector2>();
    private List<int> _validDirections = new List<int>();
    private List<int> removeValidDirections = new List<int>();

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        _controller = transform.parent.GetComponent<EnemyController>();
        _targetFollow = GameObject.Find("Player").transform;
    }
    #endregion

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        int numberDirection = (int)360 / RATE_PART_CICRLE;
        for (int i = 0; i < numberDirection; i++)
        {
            float radian = 2f * Mathf.PI / (float)numberDirection * i;
            Vector2 direction = GetPostionFromAngle(radian);
            _directions.Add(direction);
        }
    }

    public Vector3 GetDirection()
    {
     /*   if (_stopCreate == true) return;
        if (_timeCount <= TIME_DELAY_CREATE)
        {
            _timeCount += Time.deltaTime;
            return;
        }
        _timeCount = 0;*/
         return CheckAndLoadNewDirections();
    }

    private Vector3 CheckAndLoadNewDirections()
    {
        //if (_targetFollow == null) return;

        FindValidDirections();
        DodgeAvoidDirection();

        //solution for case that not having valid directions
        if (_validDirections.Count <= 2)
        {
            float angle = FindAngle();
            _validDirections.Add((int)angle / RATE_PART_CICRLE);
            _stopCreate = true;

            Extension.StartDelayAction(this, 0f, () => SetStopCreate(false));
        }
        return CreateRandomlyDirection();
    }

    private Vector3 CreateRandomlyDirection()
    {
        int v = GetPersudoRandom(PERSUDO_MESSENGE_RANDOM);
        int validDirection = _validDirections[v]; 
       // DrawLineDirections(validDirection);
        return DrawValidDirection(validDirection);
    }

    private Vector3 DrawValidDirection(int validDirection)
    {
        float x1 = _directions[validDirection].x;
        float y1 = _directions[validDirection].y;
        Vector3 directionNormalize = new Vector3((float)x1, (float)y1, 0).normalized;
        return directionNormalize;
    }

    private void DodgeAvoidDirection()
    {
        FindRemoveDirections();
        foreach (int indexRemoved in removeValidDirections)
            _validDirections.Remove(indexRemoved);
    }

    private void FindValidDirections()
    {
        _validDirections.Clear();
        for (int i = 0; i < _directions.Count; i++)
            if (OutsideTargetFollow(i * RATE_PART_CICRLE))
                _validDirections.Add(i);
    }

    private void FindRemoveDirections()
    {
        if (removeValidDirections.Count != 0) removeValidDirections.Clear();
        foreach (Vector3 avoid in _avoidDirections)
            foreach (int valid in _validDirections)
                if (CalculateAngleDiscrepancy(avoid, valid * RATE_PART_CICRLE) <= 40)
                    removeValidDirections.Add(valid);
    }

    private int GetPersudoRandom(string messenge)
    {
        if (_validDirections.Count == 0) return 0;
        messenge = StringBuilder_Messenge(messenge);

        int seed = messenge.GetHashCode();
        System.Random psuedo = new System.Random(seed);
        return psuedo.Next(_validDirections.Count);
    }

    private float FindAngle()
    {
        float t = GetAngle(GetAngleFromPosition(_targetFollow.position));
        float angle = Mathf.Repeat(t, 360f) + Random.Range(90, 180);
        angle = angle % 360;
        return angle;
    }

    #region Draw Line Directions
    private void DrawLineDirections(int validDirection)
    {
        for (int i = 0; i < _validDirections.Count; i++)
        {
            float x = _directions[_validDirections[i]].x;
            float y = _directions[_validDirections[i]].y;

            Vector3 vector3 = new Vector3((float)x, (float)y, 0);
            Vector3 pos = transform.parent.position + vector3;

            bool v = (validDirection == _validDirections[i]);
            Color colorDrawLine = v ? Color.white : Color.gray;
            Debug.DrawLine(transform.parent.position, pos, colorDrawLine, 0.01f);
        }
    }
    #endregion

    private float CalculateAngleDiscrepancy(Vector3 pos1, float radian)
    {
        float t = GetAngle(GetAngleFromPosition(pos1));
        float angle = Mathf.Repeat(t, 360f) - radian;
        float angleBetween = Mathf.Abs(angle);
        return Mathf.Min(angleBetween, 360 - angleBetween);
    }

    private float GetAngleFromPosition(Vector2 postition)
    {
        float x = postition.x - transform.parent.position.x;
        float y = postition.y - transform.parent.position.y;
        return Mathf.Atan2(y, x);
    }

    private Vector2 GetPostionFromAngle(float radian)
    {
        float x = Mathf.Cos(radian) * MAXIMUM_DISTANCE_POINT;
        float y = Mathf.Sin(radian) * MAXIMUM_DISTANCE_POINT;
        return new Vector2(x, y);
    }

    private string StringBuilder_Messenge(string messenge)
    {
        StringBuilder messengeBuidler = new StringBuilder()
            .Append(System.DateTime.Now.ToString())
            .Append(messenge)
            .Append(transform.parent.GetInstanceID());
        return messengeBuidler.ToString();
    }

    private bool OutsideTargetFollow(float radian)
    {
        float result = CalculateAngleDiscrepancy(_targetFollow.position, radian);
        return result <= RADIAN_FOLLOWED;
    }

    public void AddAnAvoidDirection(Vector3 direction) =>  _avoidDirections.Add(direction);
    public void SetTargetFollow(Transform target) => _targetFollow = target;
    public Transform TargetFollow => _targetFollow;

    private void SetStopCreate(bool status) => _stopCreate = status;
    private float GetAngle(float radian) => radian * Mathf.Rad2Deg;
}
