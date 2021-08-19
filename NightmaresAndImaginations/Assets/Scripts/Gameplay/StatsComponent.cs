using System;
using UnityEngine;

namespace TDS
{
    public class StatsComponent : MonoBehaviour
    {
        // Idea is that for buffs or debuffs, we can just modify stat modifiers
        // Other abilities come first before damage calculation
        
        // Damage calculation:
        // Player Power * PowerModifier - Enemy Defense * Enemy DefenceModifier
        
        // Assume first that there will be no max health buff or debuff abilities

        [Header("Base Stats")] 

        [SerializeField] private int baseHealth;
        [SerializeField] private int basePower;
        [SerializeField] private int baseDefense;
        [SerializeField] private int baseSpeed;

        public HealthStat Health { get; private set; }
        public UnitStat Power { get; private set; }
        public UnitStat Defense { get; private set; }
        public UnitStat Speed { get; private set; }

        public bool IsDead => Health.Value <= 0;

        public void Awake()
        {
            Health = new HealthStat(baseHealth);
            Power = new UnitStat(basePower);
            Defense = new UnitStat(baseDefense);
            Speed = new UnitStat(baseSpeed);
        }
    }
}

