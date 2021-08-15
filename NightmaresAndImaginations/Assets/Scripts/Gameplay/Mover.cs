using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(Rigidbody2D), 
                      typeof(StatsComponent))]
    public class Mover : MonoBehaviour
    {
        private float speed;
        private float speedModifier = 1.0f;
        
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            speed = GetComponent<StatsComponent>().MovementSpeed;  
            speedModifier = 1.0f;
        }

        public void SetSpeedModifier(float modifier)
        {
            speedModifier = modifier;
        }

        public void Move(Vector2 direction)
        {
            var netSpeed = speed * speedModifier * Time.fixedDeltaTime;
            var netDirection = direction * netSpeed;
            var position = (Vector2) transform.position;
            
            rigidbody2D.MovePosition(position + netDirection);
        }
    }
}
