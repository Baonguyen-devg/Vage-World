using UnityEngine;

public class LookPlayer : AutoMonobehaviour
{
    [SerializeField] private EnemyController _controller;
    [SerializeField] private Transform _player;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //_controller = transform._pointSpawn.GetComponent<EnemyController>();
        _player = GameObject.Find("Player").transform;
    }
    #endregion

    private void Update()
    {
       /* if (_controller.RandomlyMovement.TargetFollow == null) return;
        Transform _targetFollow = _controller.RandomlyMovement.TargetFollow;*/
        Look(_player);
    }

    private void Look(Transform targetFollow)
    {
        if (transform.parent.localPosition.x > targetFollow.localPosition.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
