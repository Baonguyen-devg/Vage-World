using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLoadLevelManagerSO : AutoMonobehaviour
{
    private readonly string PATH = "Level/EasyLevel_";

    [Header("[ Level Manager Scriptable Object ]"), Space(10)]
    [SerializeField] protected LevelManagerSO levelManagerSO;

    protected virtual void LoadLevelManagerSO() =>
         levelManagerSO = Resources.Load<LevelManagerSO>(PATH + GameController.Instance.Level.ToString());

    protected override void OnEnable() => LoadLevelManagerSO();
}
