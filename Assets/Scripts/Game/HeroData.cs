 using UnityEngine;

 namespace Cardho
 {

 [CreateAssetMenu(fileName = "New HeroData", menuName = "HeroData")]
    public class HeroData: ScriptableObject
    {
        public string heroName;
        public Rarity rarity;
        public Type heroType;
        public int baseHP = 100;
        public int baseSpeed = 10;
        public int baseDamage = 0;
        public int baseSlots = 3;
    }   

 }