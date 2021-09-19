using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TDS.AI
{
    public class BumpInTheNightBehaviorTree : BehaviorTree
    {
        [Header("Bump In The Night Info")] 
        [SerializeField] private float ChargeTime = 1.0f;

        [SerializeField] private float AttackTimeOffset = 0.0f;

        [SerializeField] private ShootProjectile ShootOrigin;
        
        private Enemy owner;
        private void Awake()
        {
            owner = GetComponent<Enemy>();
        }

        protected override RootNode CreateBehaviorTree()
        {
            // Depth 5
            var lauchProjectile = new ShootNode("Shoot", ShootOrigin, owner);

            // Depth 4
            var chargeNode = new ChargeNode(ChargeTime, lauchProjectile, owner);

            // Depth 3
            var idleNode = new IdleNode(owner);
            var delayNode = new DelayNode(1.0f, chargeNode, owner);

            // Depth 2
            var sequenceNode = new SequenceNode(new List<Node>
                                              {
                                                  idleNode,
                                                  delayNode
                                              },
                                              owner);
            
            // Depth 1
            var repeatNode = new RepeatNode(sequenceNode, owner, 0);

            // Depth 0
            var initialOffsetNode = new DelayNode(AttackTimeOffset, repeatNode, owner);
            
            return new RootNode(initialOffsetNode, owner);
        }
    }
}
