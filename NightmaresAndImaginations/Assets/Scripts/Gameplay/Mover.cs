using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float Speed;
        private float speedModifier = 1.0f;
        
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            speedModifier = 1.0f;
        }

        public void SetSpeedModifier(float modifier)
        {
            speedModifier = modifier;
        }

        public void Move(Vector2 direction)
        {
            rigidbody2D.velocity = (direction * (Speed * speedModifier * Time.fixedDeltaTime));
        }

        public void Stop()
        {
        }

    }
}
