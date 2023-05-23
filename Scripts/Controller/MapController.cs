using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : AutoMonobehaviour
{
    [SerializeField] protected CreateMap createMap;
    [SerializeField] protected CreateTree createTree;
    [SerializeField] protected CreateItem createItem;
    [SerializeField] protected CreateGroupEnemy createGroupEnemy;
    [SerializeField] protected Transform link;

    public CreateMap CreateMap => this.createMap;
    public CreateItem CreateItem => this.createItem;
    public CreateTree CreateTree => this.createTree;
    public CreateGroupEnemy CreateGroupEnemy => this.createGroupEnemy;
    public Transform Link => this.link;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCreateMap();
        this.LoadCreateTree();
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

    protected virtual void LoadCreateTree()
    {
        if (this.createTree != null) return;
        if (transform.Find("CreateTree") == null) return;

        if (transform.Find("CreateTree").TryGetComponent<CreateTree>(out CreateTree tree)) {
            this.createTree = tree;
        }
        Debug.Log(transform.name + ": Load CreateTree", gameObject);
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