using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class BossProjectile : MonoBehaviour
    {
        [SerializeField] private Vector2 direction;
        [SerializeField] private float speed;

        private float lifetime = 10.0f;
        private float elapsedTime;

        private Rigidbody2D rigidbody2D;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rigidbody2D.velocity = direction * speed * Time.fixedTime;
        }

        private void Update()
        {
            if (elapsedTime >= lifetime)
            {
                Destroy(gameObject);
            }
            
            elapsedTime += Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerResponse>().TakeDamage(4, transform.position.x);
                Destroy(gameObject);
            }
        }
    }

}
