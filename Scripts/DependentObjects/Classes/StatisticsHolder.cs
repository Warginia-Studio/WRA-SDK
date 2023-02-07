using UnityEditor;
using UnityEngine;
using Utility.FileManagment;

namespace DependentObjects.Classes
{
    [System.Serializable]
    public class StatisticsHolder
    {
        // HP/CONDITION/MANA
        public StatValue Health;
        public StatValue Condition;
        public StatValue Resource;
        public StatValue Mana;
    
        // REGENERATIONS
        public StatValue HealthRegen;
        public StatValue ConditionRegen;
        public StatValue ResourceRegen;
        public StatValue ManaRegen;
    
        // Light Statistics
        public StatValue AttackDamage;
        public StatValue MagicPower;
        public StatValue PhysicalDef;
        public StatValue MagicalDef;
        public StatValue AttackSpeed;
        public StatValue MovementSpeed;
    
        // Hard Statistics
        public StatValue Strenght; // e.g. AttackDamage multipliter / or additional smth 1 strenght = 100 armor
        public StatValue Inteligence; // e.g MagicPower multipliter / or additional smth 1 strenght = 100 armor
        public StatValue Dexterity; // e.g AttackSpeed / MovementSpeed multipliter / or additional smth 1 strenght = 100 armor
        public StatValue Thoughtness; // e.g AmorMultipliter / or additional smth 1 strenght = 100 armor

        // Passive Statistics
        public StatValue LifeSteal;
        public StatValue CriticalChance;
        public StatValue CooldownReduction;

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        public static void Test()
        {
            StatisticsHolder s1 = new StatisticsHolder();
            StatisticsHolder s2 = new StatisticsHolder();

            s1.Health.Value = 5;
            s2.Health.Value = 50;
            // Debug.LogError((s1+s2).Health.Value);
        }
#endif
    
        public static StatisticsHolder operator +(StatisticsHolder s1, StatisticsHolder s2)
        {
            var fields1 = s1.GetType().GetFields();
            var fields2 = s2.GetType().GetFields();

            for (int i = 0; i < fields1.Length; i++)
            {
                var stat1 = ((StatValue)fields1[i].GetValue(s1));
                var stat2 = ((StatValue)fields2[i].GetValue(s2));
                stat1.Value += stat2.Value;
                fields1[i].SetValue(s1, stat1);
            }
        
            // template help it works
            // foreach (var VARIABLE in fields)
            // {
            //     Debug.LogError(((StatValue)VARIABLE.GetValue(statisticsHolder)).Value);
            //     var stat = ((StatValue)VARIABLE.GetValue(statisticsHolder));
            //     stat.Value = 12423;
            //     VARIABLE.SetValue(statisticsHolder, stat);
            // }
            //
            // foreach (var VARIABLE in fields)
            // {
            //     Debug.LogError(((StatValue)VARIABLE.GetValue(statisticsHolder)).Value);
            // }
        
            return s1;
        }
    
        public static StatisticsHolder operator -(StatisticsHolder s1, StatisticsHolder s2)
        {
            var fields1 = s1.GetType().GetFields();
            var fields2 = s2.GetType().GetFields();

            for (int i = 0; i < fields1.Length; i++)
            {
                var stat1 = ((StatValue)fields1[i].GetValue(s1));
                var stat2 = ((StatValue)fields2[i].GetValue(s1));
                stat1.Value -= stat2.Value;
                fields1[i].SetValue(s1, stat1);
            }

            return s1;
        }
    
    }
}
