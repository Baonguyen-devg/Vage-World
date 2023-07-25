using UnityEngine;

public class Touch : AutoMonobehaviour
{
    [SerializeField] protected bool haveTouch = false;

    [Header("Necessary Controlers")]
    [SerializeField] protected ItemController itemController;
    protected virtual void LoadItemController() =>
        this.itemController ??= transform.parent?.GetComponent<ItemController>();

    [SerializeField] protected MaterialController materialController;
    protected virtual void LoadMaterialController() =>
        this.materialController ??= GameObject.Find("MaterialController")?.GetComponent<MaterialController>();

    [SerializeField] protected LootMaterial lootMaterial;
    protected virtual void LoadLootMaterialOfPlayer() =>
        this.lootMaterial ??= GameObject.Find("Player")?.transform.Find("LootMaterial")?.GetComponent<LootMaterial>();

    [SerializeField] private SpriteRenderer modelSprite;
    protected virtual void LoadModelSprite() =>
        this.modelSprite ??= transform.Find("Model")?.GetComponent<SpriteRenderer>();

    [SerializeField] private SpriteRenderer modelFrameSprite;
    protected virtual void LoadModelFrameSprite() =>
        this.modelFrameSprite ??= transform.Find("FrameModel")?.GetComponent<SpriteRenderer>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
        this.LoadLootMaterialOfPlayer();
        this.LoadMaterialController();
        this.LoadModelSprite();
        this.LoadModelFrameSprite();
    }

    public virtual void Loot()
    {
        this.materialController.IncreaseNumber(nameMaterial: transform.parent.name, number: 1);
        ItemSpawner.Instance.Despawn(obj: transform.parent);
        VFXSpawner.Instance.SpawnInRegion("Number_Pick_Item", "Forest", transform.position, transform.rotation);
        AchievementController.Instance?.GetAchievementByName(name: transform.parent.name)?.Increase(number: 1);
    }

    public virtual void ChangeStatusFrameAndHaveTouchTo(bool newStatus)
    {
        this.modelSprite.gameObject.SetActive(value: newStatus);
        this.modelFrameSprite.gameObject.SetActive(value: !newStatus);
        this.haveTouch = newStatus;
    } 
}
