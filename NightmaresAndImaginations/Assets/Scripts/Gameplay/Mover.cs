using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float Speed;
        
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            rigidbody2D.AddForce(direction * (Speed * Time.fixedDeltaTime));
        }

        public void Stop()
        {
        }

    }
}
