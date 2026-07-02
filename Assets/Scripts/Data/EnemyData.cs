using System.Collections.Generic;
using UnityEngine;

namespace Cardho
{
    [CreateAssetMenu(fileName = "New EnemyData", menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        public int maxHP = 100;
        public int speed = 5;
        public List<EnemyAction> actionPatterns = new List<EnemyAction>();
    }
}