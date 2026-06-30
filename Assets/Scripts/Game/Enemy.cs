using UnityEngine;
using Cardho;

public class Enemy : MonoBehaviour
{
   [HideInInspector] public int currentHP;
   public EnemyData enemyData;
   private int currentPatternIndex = 0;
   public int Speed => enemyData != null ? enemyData.speed : 0;
   private void Start()
    {
        if (enemyData != null)
        {
            currentHP = enemyData.maxHP;
        }
    }
    public EnemyAction GetNextAction()
    {
        if (enemyData == null || enemyData.actionPatterns.Count == 0) // Basic pattern to avoid bug
        {
            return new EnemyAction { actionType = EnemyActionType.Attack, value = 5 };
        }
        EnemyAction currentAction = enemyData.actionPatterns[currentPatternIndex];
        currentPatternIndex = (currentPatternIndex + 1) % enemyData.actionPatterns.Count;
        return currentAction;
    }
}
