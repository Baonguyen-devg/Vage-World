using UnityEngine;
using CreatingPackage;

public class MapController : AutoMonobehaviour
{
    [SerializeField] protected CreateMap createMap;
    public CreateMap CreateMap => this.createMap;
    protected virtual void LoadCreateMap() =>
        this.createMap ??= transform.Find("CreateMap")?.GetComponent<CreateMap>();

    [SerializeField] protected CreateDecorObject decorObject;
    public CreateDecorObject DecorObject => this.decorObject;
    protected virtual void LoadCreateDecorObject() =>
        this.decorObject ??= transform.Find("CreateDecorObject")?.GetComponent<CreateDecorObject>();

    [SerializeField] protected CreateItem createItem;
    public CreateItem CreateItem => this.createItem;
    protected virtual void LoadCreateItem() =>
        this.createItem ??= transform.Find("CreateItem")?.GetComponent<CreateItem>();

    [SerializeField] protected CreateGroupEnemy createGroupEnemy;
    public CreateGroupEnemy CreateGroupEnemy => this.createGroupEnemy;
    protected virtual void LoadCreateGroupEnemy() =>
        this.createGroupEnemy ??= transform.Find("CreateGroupEnemy")?.GetComponent<CreateGroupEnemy>();

    [SerializeField] protected CreateSeaDecorObject createSeaDecorObject;
    public CreateSeaDecorObject CreateSeaDecorObject => this.createSeaDecorObject;
    protected virtual void LoadCreateSeaDecorObject() =>
        this.createSeaDecorObject ??= transform.Find("CreateSeaDecorObject")?.GetComponent<CreateSeaDecorObject>();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCreateMap();
        this.LoadCreateDecorObject();
        this.LoadCreateItem();
        this.LoadCreateGroupEnemy();
        this.LoadCreateSeaDecorObject();
    }
}