using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public float actionPoint;
    public bool isDefending;
    // public List<SkillData> skills;
    public bool isPlayer;

    public bool isDead => currentHP <= 0;

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log(unitName + " was attacked! ");
        Debug.Log(unitName + "'s current HP is " + currentHP);
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        Debug.Log(unitName + " healed!");
        Debug.Log(unitName + "'s current HP is " + currentHP);
    }

    public void AddActionPoint(float amount)
    {
        actionPoint += amount;
        Debug.Log("action point increased!");
        Debug.Log("current action point is " + actionPoint);
    }

    public void ReduceActionPoint(float amount)
    {
        actionPoint = Mathf.Max(0, actionPoint - amount);
        Debug.Log("action point decreased!");
        Debug.Log("current action point is " + actionPoint);
    }
}
