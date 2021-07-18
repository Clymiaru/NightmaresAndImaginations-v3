using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private ParticleSystem SpawnVFX;

        private bool spawning;
        private float timer;
        private float duration;
        private GameObject toSpawn;
        
        public void Spawn(GameObject objectToSpawn, float spawningVFXDuration)
        {
            if (spawning)
            {
                Debug.Log($"Currently spawining {toSpawn.name}!");
                return;
            }
            
            Instantiate(SpawnVFX, transform.position, Quaternion.identity);
            spawning = true;
            timer = 0;
            duration = spawningVFXDuration;
            toSpawn = objectToSpawn;
        }

        private void Update()
        {
            if (!spawning)
            {
                return;
            }
            
            timer += Time.deltaTime;
            
            if (!(timer > duration)) 
                return;
            
            Instantiate(toSpawn, transform.position, Quaternion.identity);
            timer = 0;
            spawning = false;
            toSpawn = null;

        }
    }
}

