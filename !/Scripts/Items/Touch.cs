using UnityEngine;

public class Touch : AutoMonobehaviour
{
    [Header("Necessary Controlers")]
    [SerializeField] private SpriteRenderer _modelSprite;
    [SerializeField] private SpriteRenderer _modelFrameSprite;

    [SerializeField] protected bool _haveTouch = false;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _modelSprite = transform.Find("Model").GetComponent<SpriteRenderer>();
        _modelFrameSprite = transform.Find("Frame Model").GetComponent<SpriteRenderer>();
    }
    #endregion

    public virtual void Loot()
    {
        Effect();
        MaterialManager.Instance.IncreaseNumber(transform.parent.name, 1);
        AchievementManager.Instance.GetAchievementByName(transform.parent.name).Increase(1);
        ItemSpawner.Instance.Despawn(transform.parent);
    }

    private void Effect()
    {
        SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_COLLECT_MATERIAL);
        Transform effect = VFXSpawner.Instance.Spawn(VFXSpawner.PICK_ITEM);
        effect.position = transform.parent.position;
    }

    public virtual void ChangeStatusFrameAndHaveTouchTo(bool newStatus)
    {
        _modelSprite.gameObject.SetActive(newStatus);
        _modelFrameSprite.gameObject.SetActive(!newStatus);
        _haveTouch = newStatus;
    } 
}
