namespace TDS
{
    public class DamageEvent : Event
    {
        public DamageEvent(int damage) : base(EventType.Damage)
        {
            Damage = damage;
        }
        public int Damage { get; }
    }
}