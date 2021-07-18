﻿using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class SpawnWavesOnTrigger : MonoBehaviour
    {
        [SerializeField] private List<Wave> Waves;
        private readonly Queue<Wave> spawningWaves = new Queue<Wave>();
        private bool hasBeenTriggered;

        private void OnValidate()
        {
            var presentCollider = GetComponent<Collider2D>();
            if (presentCollider == null)
            {
                Debug.Log($"A Trigger Collider is not present for {gameObject.name}!");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            hasBeenTriggered = true;
            Debug.Log("Triggered!");
        }

        private void Start()
        {
            foreach (var wave in Waves)
            {
                spawningWaves.Enqueue(wave);
            }
        }

        private void SpawnWaves()
        {
            var current = spawningWaves.Peek();

            if (current != null && !current.HasSpawned)
            {
                current.UpdateCountdown();
                return;
            }

            spawningWaves.Dequeue();
        }
        
        private void Update()
        {
            if (!hasBeenTriggered)
            {
                return;
            }
            
            SpawnWaves();
            
            if (spawningWaves.Count <= 0)
            {
                enabled = false;
            }
        }

        private void OnDrawGizmos()
        {
            var trigger = GetComponent<CircleCollider2D>();
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, trigger.radius);
        }
    }

    // TODO: Make sure that spawn points that are in-use are not chosen until their spawn time is complete.
    // TODO: For Creepy Doll enemies, make sure that the spawn points are not used again unless killed.
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private List<Enemy> ToSpawn;
        [SerializeField] private List<SpawnPoint> SpawnPoints;
        [SerializeField] private float SpawnDelay;
        
        public bool HasSpawned { get; private set; } 

        public void UpdateCountdown()
        {
            if (HasSpawned)
            {
                return;
            }
            
            SpawnDelay -= Time.deltaTime;

            if (SpawnDelay < 0.0f)
            {
                SpawnWave();
            }
        }

        private void SpawnWave()
        {
            foreach (var spawn in ToSpawn)
            {
                var chosenSpawnPointIndex = UnityEngine.Random.Range(0, SpawnPoints.Count);
                SpawnPoints[chosenSpawnPointIndex].Spawn(spawn.gameObject, 5.0f);
            }
            
            HasSpawned = true;
        }
    }
}