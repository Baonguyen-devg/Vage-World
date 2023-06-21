using UnityEngine;

public class Touch : AutoMonobehaviour
{
    [SerializeField] protected bool haveTouch = false;

    [Header("Necessary Controlers")]
    [SerializeField] protected ItemController itemController;
    [SerializeField] protected MaterialController materialController;
    [SerializeField] protected LootMaterial lootMaterial;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
        this.LoadLootMaterialOfPlayer();
        this.LoadMaterialController();
    }

    protected virtual void LoadMaterialController() =>
        this.materialController = (this.materialController != null) ? this.materialController
            : GameObject.Find("MaterialController").GetComponent<MaterialController>();

    protected virtual void LoadLootMaterialOfPlayer() =>
        this.lootMaterial = (this.lootMaterial != null) ? this.lootMaterial
            : GameObject.Find("Player").transform.Find("LootMaterial").GetComponent<LootMaterial>();

    protected virtual void LoadItemController() =>
        this.itemController = (this.itemController != null) ? this.itemController
            : transform.parent.GetComponent<ItemController>();

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && this.haveTouch)
               this.lootMaterial.SetItemToPickup(transform.parent.gameObject, transform.GetComponent<Touch>());
    }

    public virtual void Loot()
    {
        this.materialController.IncreaseNumber(transform.parent.name, 1);
        ItemSpawner.Instance.Despawn(transform.parent);
        AstarPath.active.Scan();
    }

    public virtual void OnMouseEnter() => this.ChangeStatusFrameAndHaveTouchTo(true);

    public virtual void OnMouseExit() => this.ChangeStatusFrameAndHaveTouchTo(false);

    protected virtual void ChangeStatusFrameAndHaveTouchTo(bool newStatus)
    {
        this.itemController.Frame.Find("Model").gameObject.SetActive(newStatus);
        this.haveTouch = newStatus;
    } 
}
