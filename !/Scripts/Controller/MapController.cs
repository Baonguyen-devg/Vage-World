using UnityEngine;
using CreatingPackage;

public class MapController : AutoMonobehaviour
{
    [SerializeField] protected CreateMap createMap;
    [SerializeField] protected CreateLandDecorationGroups decorObject;
    [SerializeField] protected CreateItemGroups createItem;
    [SerializeField] protected CreateSeaDecorationGroups createSeaDecorObject;
    [SerializeField] protected CreateEnemyGroups createGroupEnemy;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        createMap = transform.Find("Create Map").GetComponent<CreateMap>();
        decorObject = transform.Find("Create Land Decoration Groups").GetComponent<CreateLandDecorationGroups>();
        createItem = transform.Find("Create Item Groups").GetComponent<CreateItemGroups>();
        createGroupEnemy = transform.Find("Create Enemy Groups").GetComponent<CreateEnemyGroups>();
        createSeaDecorObject = transform.Find("Create Sea Decoration Groups").GetComponent<CreateSeaDecorationGroups>();
    }

    public CreateMap CreateMap => createMap;
    public CreateLandDecorationGroups DecorObject => decorObject;
    public CreateItemGroups CreateItem => createItem;
    public CreateEnemyGroups CreateGroupEnemy => createGroupEnemy;
    public CreateSeaDecorationGroups CreateSeaDecorObject => createSeaDecorObject;
}