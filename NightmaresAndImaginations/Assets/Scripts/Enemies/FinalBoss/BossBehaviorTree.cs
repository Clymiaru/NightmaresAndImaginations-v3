using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TDS.AI
{
    public class BossBehaviorTree : BehaviorTree
    {
        [SerializeField] private Mover mover;
        [SerializeField] private TargetPositionChecker positionChecker;

        private Enemy owner;
        private GameObject target;
        private Sensor sensor;
        
        protected override RootNode CreateBehaviorTree()
        {
            var idleNode = new IdleNode(owner);

            var doNothingNode = new DoNothingNode(owner);

            var isDeadNode = new IsDeadNode(doNothingNode, owner, "Death");
            
            // Slash attack
            var slashSequenceNode = new SequenceNode(new List<Node>
                                                     {
                                                         new BossSlashArmUpNode(owner),
                                                         new BossSlashChargingNode(owner),
                                                         new BossSlashNode(owner)
                                                     }, 
                                                     owner);
            // Slam attack
            var slamSequenceNode = new SequenceNode(new List<Node>
                                                    {
                                                        new BossSlamArmUpNode(owner),
                                                        new BossSlamChargingNode(owner),
                                                        new BossSlamNode(owner)
                                                    },
                                                    owner);
            
            var delayNode = new DelayNode(1.2f, doNothingNode,
                                                    owner);
            

            var patternA = new SequenceNode(new List<Node>
                                            {
                                                slashSequenceNode,
                                                delayNode,
                                                slashSequenceNode,
                                            },
                                            owner);
            
            var patternB = new SequenceNode(new List<Node>
                                            {
                                                slamSequenceNode,
                                                delayNode,
                                                slamSequenceNode
                                            },
                                            owner);
            
            var actionSequence = new SequenceNode(new List<Node>
                                                  {
                                                      patternA,
                                                      patternB
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
