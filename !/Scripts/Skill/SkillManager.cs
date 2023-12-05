using System.Collections.Generic;
using UnityEngine;

public class SkillManager : AutoMonobehaviour
{
    private static SkillManager instance;
    public static SkillManager Instance => instance;

    [SerializeField] private List<SkillController> skillPrefab;
    [SerializeField] private Attack.PlayerShootingAttack playerShooting;

    [SerializeField] private bool canUseSkill_1;
    [SerializeField] private bool canUseSkill_2;
    [SerializeField] private bool canUseSkill_3;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        if (skillPrefab.Count != 0) skillPrefab.Clear();
        foreach (Transform prefab in transform)
            skillPrefab.Add(prefab.GetComponent<SkillController>());
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        SkillManager.instance = this;
    }

    //con thoi gian thi cai tien them
    public virtual void ChangeStatusSkills()
    {
        canUseSkill_1 = GetPrefabByName("Skill 1").IsCanUse();
        canUseSkill_2 = GetPrefabByName("Skill 2").IsCanUse();
        canUseSkill_3 = GetPrefabByName("Skill 3").IsCanUse();

        if (canUseSkill_1) playerShooting.SetActiveTeamSupporter(true);
        else playerShooting.SetActiveTeamSupporter(false);
    }

    public SkillController GetPrefabByName(string name)
    {
        foreach (SkillController prefab in skillPrefab)
            if (name.Equals(prefab.name)) return prefab;
        return null;
    }

    public bool CanUseSkill_1() => canUseSkill_1;
    public bool CanUseSkill_2() => canUseSkill_2;
    public bool CanUseSkill_3() => canUseSkill_3;
}