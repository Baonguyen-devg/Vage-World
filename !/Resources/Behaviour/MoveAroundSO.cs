using UnityEngine;

[CreateAssetMenu(fileName = "MoveAround")]
public class MoveAroundSO : ScriptableObject, IBehaviourSO
{
    [Header("That fields must be referenced form object parent"), Space(6)]
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;

    [Header("Edit from sciptable object file"), Space(6)]
    [SerializeField] private float _speed;
    [SerializeField] public float _timeDelay;

    private float _timeStart; 
    private float _radius;

    private void Awake()
    {
        _timeStart = Time.time;
        _radius = Random.Range(4, 6);
    }

    public void DoBehaviour()
    {
        float angle = _timeStart + Time.time;
        float x = _targetFollow.position.x + Mathf.Cos(angle) * _radius;
        float y = _targetFollow.position.y + Mathf.Sin(angle) * _radius;

        Vector3 direction = GetNormailzed(_parent.position, new Vector3(x, y, 0));
        _parent.position = Vector3.Lerp(_parent.position,
            _parent.position + direction, _speed);
    }

    private Vector3 GetNormailzed(Vector3 A, Vector3 B) => (B - A).normalized;

    public void SetParent(Transform parent) => _parent = parent;
    public void SetTargetFollow(Transform target) => _targetFollow = target;
    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
