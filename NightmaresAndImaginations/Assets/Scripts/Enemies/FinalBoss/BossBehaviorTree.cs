using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace TDS.AI
{
    public class BossBehaviorTree : BehaviorTree
    {
        [SerializeField] private Mover Mover;
        [SerializeField] private TargetPositionChecker PositionChecker;
        [SerializeField] private BossBulletHellHandler BulletHellHandler;
        [SerializeField] private GameObject GroundAttackCollider;
        
        private Enemy owner;
        private GameObject target;
        private Sensor sensor;
        
        protected override RootNode CreateBehaviorTree()
        {
            var idleNode = new IdleNode(owner);

            var doNothingNode = new DoNothingNode(owner);

            var isDeadNode = new IsDeadNode(doNothingNode, owner, "Death");
            
            // Bullet hell segment
            var bulletSequenceNode = new SequenceNode(new List<Node>
                                                     {
                                                         new BossSlashArmUpNode(owner),
                                                         new BossBulletHellNode(BulletHellHandler, owner),
                                                         new DelayNode(3.0f, doNothingNode, owner)
                                                     }, 
                                                     owner);
            
            // Slash attack
            var slashSequenceNode = new SequenceNode(new List<Node>
                                                     {
                                                         new BossSlashArmUpNode(owner),
                                                         new BossSlashChargingNode(owner),
                                                         new BossSlashNode(GroundAttackCollider, owner),
                                                         new DisableObjectNode(GroundAttackCollider, owner)
                                                     }, 
                                                     owner);
            // Slam attack
            var slamSequenceNode = new SequenceNode(new List<Node>
                                                    {
                                                        new BossSlamArmUpNode(owner),
                                                        new BossSlamChargingNode(owner),
                                                        new BossSlamNode(GroundAttackCollider, owner),
                                                        new DisableObjectNode(GroundAttackCollider, owner)
                                                    },
                                                    owner);
            
            var delayNode = new DelayNode(1.2f, doNothingNode,
                                                    owner);
            

            var patternA = new SequenceNode(new List<Node>
                                            {
                                                slashSequenceNode,
                                                slashSequenceNode,
                                                delayNode,
                                            },
                                            owner);
            
            var patternB = new SequenceNode(new List<Node>
                                            {
                                                slamSequenceNode,
                                                slashSequenceNode,
                                                delayNode,
                                                slamSequenceNode
                                            },
                                            owner);
            
            var patternC = new SequenceNode(new List<Node>
                                            {
                                                slamSequenceNode,
                                                bulletSequenceNode,
                                                delayNode,
                                                delayNode,
                                                bulletSequenceNode,
                                                delayNode
                                            },
                                            owner);
            
            var actionSequence = new SequenceNode(new List<Node>
                                                  {
                                                      patternA,
                                                      patternB,
                                                      patternC
                                                  },
                                                  owner);

            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isDeadNode,
                                                  actionSequence,
                                                  idleNode
                                              },
                                              owner);
            
            
            var repeatNode = new RepeatNode(selectNode, owner, 0);
            
            return new RootNode(repeatNode, owner);
        }

        private void Awake()
        {
            owner = GetComponent<Enemy>();
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
