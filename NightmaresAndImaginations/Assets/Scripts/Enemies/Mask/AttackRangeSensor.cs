using UnityEngine;

namespace TDS
{
    public class AttackRangeSensor : MonoBehaviour
    {
        public bool InRange { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                InRange = true;
            }
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!InRange && other.CompareTag("Player"))
            {
                InRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                InRange = false;
            }
        }
    }
}

