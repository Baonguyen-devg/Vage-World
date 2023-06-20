using UnityEngine;

public class MapController : AutoMonobehaviour
{
    [SerializeField] protected CreateMap createMap;
    [SerializeField] protected CreateDecorObject decorObject;
    [SerializeField] protected CreateItem createItem;
    [SerializeField] protected CreateGroupEnemy createGroupEnemy;
    [SerializeField] protected Transform link;

    public CreateMap CreateMap => this.createMap;
    public CreateItem CreateItem => this.createItem;
    public CreateDecorObject DecorObject => this.decorObject;
    public CreateGroupEnemy CreateGroupEnemy => this.createGroupEnemy;
    public Transform Link => this.link;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCreateMap();
        this.LoadCreateDecorObject();
        this.LoadCreateItem();
        this.LoadCreateGroupEnemy();
        this.LoadLink();
    }

    protected virtual void LoadLink()
    {
        if (this.link != null) return;
        this.link = transform.Find("Link");
        Debug.Log(transform.name + ": Load Link", gameObject);
    }

    protected virtual void LoadCreateMap()
    {
        if (this.createMap != null) return;
        this.createMap = transform.Find("CreateMap").GetComponent<CreateMap>();
        Debug.Log(transform.name + ": Load CreateMap", gameObject);
    }

    protected virtual void LoadCreateDecorObject()
    {
        if (this.decorObject != null) return;
        if (transform.Find("CreateDecorObject") == null) return;

        if (transform.Find("CreateDecorObject").TryGetComponent<CreateDecorObject>(out CreateDecorObject tree))
        {
            this.decorObject = tree;
        }
        Debug.Log(transform.name + ": Load DecorObject", gameObject);
    }

    protected virtual void LoadCreateItem()
    {
        if (this.createItem != null) return;
        this.createItem = transform.Find("CreateItem").GetComponent<CreateItem>();
        Debug.Log(transform.name + ": Load CreateItem", gameObject);
    }

    protected virtual void LoadCreateGroupEnemy()
    {
        if (this.createGroupEnemy != null) return;
        this.createGroupEnemy = transform.Find("CreateGroupEnemy").GetComponent<CreateGroupEnemy>();
        Debug.Log(transform.name + ": Load CreateGroupEnemy", gameObject);
    }
}