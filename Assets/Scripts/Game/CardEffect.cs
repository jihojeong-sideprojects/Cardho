using UnityEngine;

namespace Cardho{

[CreateAssetMenu(fileName = "New CardEffect", menuName = "CardEffect")]

public class CardEffect : ScriptableObject
{
    public string effectName;
    public Effect effect;
}

[System.Serializable] 
public struct Effect
{
    public EffectType effecttype;
    public int effectduration;
    public int effectamount;
}
}