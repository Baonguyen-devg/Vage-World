using UnityEngine;

public class MoveAround : MonoBehaviour, IBehaviourSO
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private float _speed;
    [SerializeField] public float _timeDelay;

    private float _timeStart;
    private float _radius;

    private void OnEnable()
    {
        _timeStart = Time.time + gameObject.GetInstanceID();
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

    public void SetTargetFollow(Transform target) => _targetFollow = target;
    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
