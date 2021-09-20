using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class BossBulletHellHandler : MonoBehaviour
    {
        [SerializeField] private List<BossProjectileSource> BulletSources;

        public void Shoot()
        {
            foreach (var source in BulletSources)
            {
                source.Spawn();
            }
        }
    }
}
