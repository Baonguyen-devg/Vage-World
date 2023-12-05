using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullSpawnerPrefab : AutoMonobehaviour, IBehaviourSO
{
    [SerializeField] protected List<SpacePrefab> spaces;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private float _timeDelay;

    private bool _canAttack = false;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        spaces.Clear();
        foreach (Transform prefab in transform)
            spaces.Add(prefab.GetComponent<SpacePrefab>());
    }
    #endregion

    public void DoBehaviour()
    {
        if (!_canAttack) return;
        Extension.StartDelayAction(this, 1f, () =>
        {
            foreach (SpacePrefab space in spaces)
                space.Spawner("Fire_Skull");
        });
        _canAttack = false;
    }

    public void SetTargetFollow(Transform target)
    {
        _canAttack = false;
        _targetFollow = target;

        Extension.StartDelayAction(this, 0.2f, () => {
            _canAttack = true;
        });
    }

    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
}
