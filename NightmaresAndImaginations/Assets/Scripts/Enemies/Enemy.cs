using System;
using UnityEngine;

namespace TDS
{
    public abstract class Enemy : MonoBehaviour
    {
        protected abstract void OnSpawn();

        public void Spawn()
        {
            OnSpawn();
        }
    }
}