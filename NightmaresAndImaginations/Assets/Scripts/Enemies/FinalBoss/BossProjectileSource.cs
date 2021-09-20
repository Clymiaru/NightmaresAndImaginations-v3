using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class BossProjectileSource : MonoBehaviour
    {
        [SerializeField] private List<BossProjectile> BulletPool;

        public void Spawn()
        {
            var index = Random.Range(0, BulletPool.Count);
            var spawned = Instantiate(BulletPool[index].gameObject, transform.position, Quaternion.identity);
            spawned.transform.parent = gameObject.transform;
        }
    }

}
