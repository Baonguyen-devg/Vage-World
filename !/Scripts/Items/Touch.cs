using UnityEngine;

public class Touch : AutoMonobehaviour
{
    [Header("Necessary Controlers")]
    [SerializeField] private SpriteRenderer _modelSprite;
    [SerializeField] private SpriteRenderer _modelFrameSprite;

    [SerializeField] protected bool _haveTouch = false;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _modelSprite = transform.Find("Model").GetComponent<SpriteRenderer>();
        _modelFrameSprite = transform.Find("Frame Model").GetComponent<SpriteRenderer>();
    }

    public virtual void Loot()
    {
        MaterialManager.Instance.IncreaseNumber(transform.parent.name, 1);
        //AchievementController.Instance.GetAchievementByName(transform.parent.name).Increase(1);*/
        Transform effect = VFXSpawner.Instance.Spawn(VFXSpawner.PICK_ITEM);
        effect.position = transform.parent.position;

        SFXSpawner.Instance.PlaySound(SFXSpawner.SOUND_COLLECT_MATERIAL);
        ItemSpawner.Instance.Despawn(transform.parent);
    }

    public virtual void ChangeStatusFrameAndHaveTouchTo(bool newStatus)
    {
        _modelSprite.gameObject.SetActive(newStatus);
        _modelFrameSprite.gameObject.SetActive(!newStatus);
        _haveTouch = newStatus;
    } 
}
