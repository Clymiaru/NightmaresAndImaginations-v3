using UnityEngine;

namespace TDS
{
    public class UnitStat
    {
        protected int BaseValue;
        private float modifier;

        public UnitStat(int baseValue)
        {
            BaseValue = baseValue;
            modifier = 1.0f;
        }

        public int Value => Mathf.RoundToInt(BaseValue * modifier);

        public void Buff(float buffAmount)
        {
            modifier += buffAmount;
        }
        
        public void Debuff(float debuffAmount)
        {
            modifier -= debuffAmount;
        }

        public void ResetStatus()
        {
            modifier = 1.0f;
        }
    }
}

