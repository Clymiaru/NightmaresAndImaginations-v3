namespace TDS
{
    public class Mask : Enemy
    {
        protected override void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
