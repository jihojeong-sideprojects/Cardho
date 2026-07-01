using UnityEngine;

namespace Cardho{
#region basedata
public enum Rarity
    {
        Normal,
        Rare,
        Unique
    }
public enum PrimeStat
{
    Strength,
    Agaility,
    Intelligence,
    Universal
}
#endregion
#region damage
public enum DamageType
        {
            Physical,
            Magic,
            True,
            Duration
        }

public struct Attack
    {
        public DamageType type;
        public int minDamage;
        public int maxDamage;
    }
#endregion
#region effect
public enum EffectType
        {
            Damage,
            Heal,
            Stun    
        }
[System.Serializable] 
public struct Effect
{
    public EffectType effecttype;
    public int effectduration;
    public int effectamount;
}
#endregion
#region Enemy


[System.Serializable] 
public enum EnemyActionType
    {
        Attack,
        Heal
    }
[System.Serializable]
    public struct EnemyAction
    {
        public EnemyActionType actionType;
        public int value;
    }
  
    #endregion


    public enum BattleState
    {
        Ready,
        BattlePhase,
        Win,
        Lose
        
    }
}
