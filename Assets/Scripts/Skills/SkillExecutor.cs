using System.Collections.Generic;
using UnityEngine;

public class SkillExecutor : MonoBehaviour
{
    public void Execute(SkillData skill, BattleUnit user, List<BattleUnit> targets)
    {
        switch (skill.type)
        {
            case SkillType.Single:
                targets[0].TakeDamage(skill.value);
                break;
            case SkillType.Area: // TODO : Area 설정
                foreach (var t in targets) t.TakeDamage(skill.value);
                break;
            case SkillType.Defend:
                user.isDefending = true;
                break;
            case SkillType.Heal:
                user.Heal(skill.value);
                break;
            case SkillType.ReduceAP: // TODO : 공격 대상 설정
                targets[0].ReduceActionPoint(skill.value);
                break;
        }
        TurnManager.Instance.OnSkillUsed(user, skill.apCost);
    }
}
