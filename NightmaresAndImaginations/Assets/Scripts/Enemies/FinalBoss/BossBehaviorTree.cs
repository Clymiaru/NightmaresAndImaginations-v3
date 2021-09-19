using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossBehaviorTree : BehaviorTree
    {
        [SerializeField] private Mover mover;
        
        private Enemy owner;
        private GameObject target;
        
        protected override RootNode CreateBehaviorTree()
        {
            
            var idleNode = new IdleNode(owner);
            
            var delayedFollowTargetNode = new DelayedFollowTargetNode(target, mover, owner);

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

            var randomActionNode = new RandomActionSelectionNode(new List<Node>
                                                                 {
                                                                     slashSequenceNode,
                                                                     slamSequenceNode,
                                                                     delayedFollowTargetNode,
                                                                     idleNode
                                                                 },
                                                                 owner);

            
            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isDeadNode,
                                                  randomActionNode,
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
