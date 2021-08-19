using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Mask : Enemy
    {
        protected override void OnSpawn()
        {
        }

        protected override void OnDeath()
        {
            Destroy(gameObject);
        }
        
        
    }
}
