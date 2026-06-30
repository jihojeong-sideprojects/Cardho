using System.Collections.Generic;
using UnityEngine;

namespace Cardho
{
      
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card: ScriptableObject
    {
        public string cardName;
        public Rarity rarity;
        public Type cardType;
        public DamageType damageType;
        public int damangeMin;
        public int damageMax;
        public int turnCycle;
        public CardEffect[] effects;

        
        public enum DamageType
        {
            Physical,
            Magic,
            True,
            Duration
        }
        
    }
   
}