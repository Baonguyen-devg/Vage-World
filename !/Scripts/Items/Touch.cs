using UnityEngine;

public class Touch : AutoMonobehaviour
{
    [SerializeField] protected ItemController controller;
    public ItemController Controller => this.controller;
    [SerializeField] protected bool haveTouch = false;

    [SerializeField] protected MaterialController materialCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && this.haveTouch == true)
                GameObject.Find("Player").transform.
                    Find("LootMaterial").GetComponent<LootMaterial>()
                    .SetItemToPickup(transform.parent.gameObject, transform.GetComponent<Touch>());
    }

    protected virtual void LoadItemController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": Load ItemController", gameObject); ;
    }

    public virtual void Loot()
    {
        if (this.materialCtrl == null)
            this.materialCtrl = GameObject.Find("MaterialController").GetComponent<MaterialController>();
        this.materialCtrl.IncreaseNumber(transform.parent.name, 1);
        ItemSpawner.Instance.Despawn(transform.parent);
        AstarPath.active.Scan();
    }

    public virtual void OnMouseEnter()
    {
        this.controller.Frame.Find("Model").gameObject.SetActive(true);
        this.haveTouch = true;
    }

    public virtual void OnMouseExit()
    {
        this.controller.Frame.Find("Model").gameObject.SetActive(false);
        this.haveTouch = false;
    }
}
