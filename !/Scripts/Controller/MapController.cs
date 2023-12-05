using UnityEngine;
using CreatingPackage;

public class MapController : AutoMonobehaviour
{
    [SerializeField] private CreateMap _createMap;
    [SerializeField] private CreateLandDecorationGroups _decorObject;
    [SerializeField] private CreateItemGroups _createItem;
    [SerializeField] private CreateSeaDecorationGroups _createSeaDecorObject;
    [SerializeField] private CreateEnemyGroups _createGroupEnemy;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        _createMap = transform.Find("Create Map").GetComponent<CreateMap>();
        _decorObject = transform.Find("Create Land Decoration Groups").GetComponent<CreateLandDecorationGroups>();
        _createItem = transform.Find("Create Item Groups").GetComponent<CreateItemGroups>();
        _createGroupEnemy = transform.Find("Create Enemy Groups").GetComponent<CreateEnemyGroups>();
        _createSeaDecorObject = transform.Find("Create Sea Decoration Groups").GetComponent<CreateSeaDecorationGroups>();
    }
    #endregion

    public CreateMap CreateMap => _createMap;
    public CreateLandDecorationGroups DecorObject => _decorObject;
    public CreateItemGroups CreateItem => _createItem;
    public CreateEnemyGroups CreateGroupEnemy => _createGroupEnemy;
    public CreateSeaDecorationGroups CreateSeaDecorObject => _createSeaDecorObject;
}