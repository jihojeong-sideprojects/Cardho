using System.Collections;
using System.Collections.Generic;
using Cardho;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("In Battle")]
    public List<Hero> playerHeroes = new List<Hero>();
    public List<Enemy> enemyUnits = new List<Enemy>();

    [Header("Current Round/State")]
    public int currentTurn = 1;
    public BattleState currentState;

    private void Start()
    {
        ChangeState(BattleState.Ready);
    }

    public void ChangeState(BattleState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case BattleState.Ready:
                SetupBattle();
                break;
            case BattleState.BattlePhase:
                StartCoroutine(TurnRoutine());
                break;
            case BattleState.Win:
                Debug.Log("WIN");
                break;
            case BattleState.Lose:
                Debug.Log("LOSE");
                break;
        }
    }
    private string TurnRoutine()
    {
        return ("");
        
    }

    private void SetupBattle()
    {
        currentTurn = 1;
        ChangeState(BattleState.BattlePhase);
    }

}
