using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/Skills/SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public SkillType type; // 열거형: Single, Area, Defend, Heal, ReduceAP
    public float apCost;   // 사용 시 추가되는 행동 수치
    public int value;      // 데미지, 회복량, AP감소량 등
}
