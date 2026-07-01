using UnityEngine;

namespace Cardho{

[CreateAssetMenu(fileName = "New CardEffect", menuName = "CardEffect")]

public class CardEffect : ScriptableObject
{
    public string effectName;
    public Effect effect;
}

}