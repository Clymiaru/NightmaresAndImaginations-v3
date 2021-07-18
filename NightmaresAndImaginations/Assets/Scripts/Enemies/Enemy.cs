using System;
using UnityEngine;

namespace TDS
{
    public abstract class Enemy : MonoBehaviour
    {
        public virtual void OnSpawn()
        {
            
        }

        public void Spawn()
        {
            OnSpawn();
            gameObject.SetActive(true);
        }
    }
}