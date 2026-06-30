using System.Collections.Generic;
using UnityEngine;

namespace Cardho
{
      
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card: ScriptableObject
    {
        public string cardName;
        public Rarity rarity;
        public PrimeStat primeStat;
        public Attack attack;
        public int turnCycle;
        public CardEffect[] effects;           
    }
   
}