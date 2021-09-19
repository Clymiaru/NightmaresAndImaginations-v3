using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class ShootProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject ProjectileTemplate;

        public void Shoot()
        {
            Instantiate(ProjectileTemplate, transform.position, Quaternion.identity);
        }
    }    
}


