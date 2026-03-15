using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;

    public static TurnManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<BattleUnit> units;

    public BattleUnit GetCurrentUnit()
    {
        // AP가 가장 낮은 유닛 (=현재 턴) 반환
        return units.OrderBy(u => u.actionPoint).First();
    }

    public void OnSkillUsed(BattleUnit user, float apCost)
    {
        user.AddActionPoint(apCost);
        StartNextTurn();
    }

    private void StartNextTurn()
    {
        units.RemoveAll(u => u.isDead);
        // TODO : if (IsBattleOver()) return;
        BattleUnit next = GetCurrentUnit();
        Debug.Log(next.unitName + " is turn now!");
    }
}
