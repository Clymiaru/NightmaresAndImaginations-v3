using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace TDS
{
    [RequireComponent(typeof(Rigidbody2D), 
                      typeof(StatsComponent))]
    public class Mover : MonoBehaviour
    {
        private float speed;
        private float speedModifier = 1.0f;
        
        private new Rigidbody2D rigidbody2D;

        private Vector2 netDirection;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            speed = GetComponent<StatsComponent>().Speed.Value;  
            speedModifier = 1.0f;
        }

        public void SetSpeedModifier(float modifier)
        {
            speedModifier = modifier;
        }

        public void Move(Vector2 direction)
        {
            var netSpeed = speed * speedModifier * Time.fixedDeltaTime;
            netDirection = direction * netSpeed;
        }

        public void Stop()
        {
            netDirection = Vector2.zero;
        }

        public void FixedUpdate()
        {
            rigidbody2D.velocity = netDirection;
        }
    }
}
