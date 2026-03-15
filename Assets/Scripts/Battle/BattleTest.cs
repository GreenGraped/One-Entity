using System.Collections.Generic;
using UnityEngine;

public class BattleTest : MonoBehaviour
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = GetComponent<TurnManager>();

        // 유닛 생성
        BattleUnit player = CreateUnit("플레이어", 100, 0f);
        BattleUnit enemy1 = CreateUnit("적 1", 50, 0f);
        BattleUnit enemy2 = CreateUnit("적 2", 50, 0f);

        turnManager.units = new List<BattleUnit> { player, enemy1, enemy2 };

        // 첫 턴 확인
        Debug.Log("첫 턴: " + turnManager.GetCurrentUnit().unitName);

        // 스킬 사용 시뮬레이션
        turnManager.OnSkillUsed(player, 10f);
        Debug.Log("플레이어 AP 10 사용 후 턴: " + turnManager.GetCurrentUnit().unitName);

        turnManager.OnSkillUsed(enemy1, 8f);
        Debug.Log("적1 AP 8 사용 후 턴: " + turnManager.GetCurrentUnit().unitName);
    }

    private BattleUnit CreateUnit(string name, int hp, float ap)
    {
        GameObject obj = new GameObject(name);
        BattleUnit unit = obj.AddComponent<BattleUnit>();
        unit.unitName = name;
        unit.maxHP = hp;
        unit.currentHP = hp;
        unit.actionPoint = ap;
        return unit;
    }
}
