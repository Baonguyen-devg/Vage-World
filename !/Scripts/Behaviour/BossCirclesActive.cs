using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCirclesActive : AutoMonobehaviour, IBehaviourSO
{
    private readonly int TRIGGER_BREATH = Animator.StringToHash("Breath");
    private readonly int TRIGGER_BLACK_SCREEN = Animator.StringToHash("Black_Screen");

    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private float _timeDelay;

    [SerializeField] private Animator animatorBoss;
    [SerializeField] private Animator animatorBackgroundColor;
    [SerializeField] private List<Transform> circlePrefabs;

    private bool canAttack = false;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        circlePrefabs.Clear();
        foreach (Transform prefab in transform)
            circlePrefabs.Add(prefab);
    }
    #endregion

    public void DoBehaviour()
    {
        if (!canAttack) return;

        animatorBoss.SetTrigger(TRIGGER_BREATH);
        animatorBackgroundColor.SetTrigger(TRIGGER_BLACK_SCREEN);
        SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_BOSS_ROAR);

        Extension.StartDelayAction(this, 1.2f, () =>
        {
            foreach (Transform circle in circlePrefabs)
                circle.gameObject.SetActive(true);
        });
        canAttack = false;
    }

    public void SetTargetFollow(Transform target)
    {
        canAttack = false;
        _targetFollow = target;

        Extension.StartDelayAction(this, 0.2f, () => {
            canAttack = true;
        });
    }

    public float GetTimeDelay() => _timeDelay;
    public bool IsFinished() => false;
    public List<Transform> CirclePrefabs => circlePrefabs;
}
