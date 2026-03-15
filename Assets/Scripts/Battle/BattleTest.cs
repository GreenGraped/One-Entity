using System.Collections.Generic;
using UnityEngine;

public class BattleTest : MonoBehaviour
{
    private SkillExecutor skillExecutor;

    void Start()
    {
        skillExecutor = gameObject.AddComponent<SkillExecutor>();

        // 유닛 생성
        BattleUnit player = CreateUnit("플레이어", 100, 0f, true);
        BattleUnit enemy1 = CreateUnit("적 1", 50, 0f, false);
        BattleUnit enemy2 = CreateUnit("적 2", 50, 0f, false);

        TurnManager.Instance.units = new List<BattleUnit> { player, enemy1, enemy2 };

        Debug.Log("=== 전투 시작 ===");
        Debug.Log("첫 턴: " + TurnManager.Instance.GetCurrentUnit().unitName);

        // testSkill 로드 (Resources/Skills/ 폴더 기준)
        SkillData testSkill = Resources.Load<SkillData>("Skills/testSkill");
        if (testSkill == null)
        {
            Debug.LogError("testSkill을 찾을 수 없습니다. Resources/Skills/ 경로를 확인하세요.");
            return;
        }

        Debug.Log("=== 플레이어가 적 1에게 스킬 사용 ===");
        skillExecutor.Execute(testSkill, player, new List<BattleUnit> { enemy1 });

        Debug.Log("=== 적 1이 플레이어에게 스킬 사용 ===");
        skillExecutor.Execute(testSkill, enemy1, new List<BattleUnit> { player });
    }

    private BattleUnit CreateUnit(string name, int hp, float ap, bool isPlayer)
    {
        GameObject obj = new GameObject(name);
        BattleUnit unit = obj.AddComponent<BattleUnit>();
        unit.unitName = name;
        unit.maxHP = hp;
        unit.currentHP = hp;
        unit.actionPoint = ap;
        unit.isPlayer = isPlayer;
        return unit;
    }
}