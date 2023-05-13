using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : AutoMonobehaviour
{
    [SerializeField] protected CreateMap createMap;
    [SerializeField] protected CreateTree createTree;
    [SerializeField] protected CreateStone createStone;
    [SerializeField] protected CreateGrass createGrass;
    [SerializeField] protected CreateGroupEnemy createGroupEnemy;
    [SerializeField] protected Transform link;

    public CreateMap CreateMap => this.createMap;
    public CreateGrass CreateGrass => this.createGrass;
    public CreateStone CreateStone => this.createStone;
    public CreateTree CreateTree => this.createTree;
    public CreateGroupEnemy CreateGroupEnemy => this.createGroupEnemy;
    public Transform Link => this.link;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCreateMap();
        this.LoadCreateTree();
        this.LoadCreateStone();
        this.LoadCreateGrass();
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
        this.createTree = transform.Find("CreateTree").GetComponent<CreateTree>();
        Debug.Log(transform.name + ": Load CreateTree", gameObject);
    }

    protected virtual void LoadCreateStone()
    {
        if (this.createStone != null) return;
        this.createStone = transform.Find("CreateStone").GetComponent<CreateStone>();
        Debug.Log(transform.name + ": Load CreateStone", gameObject);
    }

    protected virtual void LoadCreateGrass()
    {
        if (this.createGrass != null) return;
        this.createGrass = transform.Find("CreateGrass").GetComponent<CreateGrass>();
        Debug.Log(transform.name + ": Load CreateGrass", gameObject);
    }

    protected virtual void LoadCreateGroupEnemy()
    {
        if (this.createGroupEnemy != null) return;
        this.createGroupEnemy = transform.Find("CreateGroupEnemy").GetComponent<CreateGroupEnemy>();
        Debug.Log(transform.name + ": Load CreateGroupEnemy", gameObject);
    }
}