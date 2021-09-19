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
            var obj = Instantiate(ProjectileTemplate, transform.position, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }    
}


