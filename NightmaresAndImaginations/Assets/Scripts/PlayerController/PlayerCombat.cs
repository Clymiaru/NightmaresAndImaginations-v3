using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerCombat : MonoBehaviour
{
    private bool isAttackPressed = false;
    private bool isAttacking = false;
    private float attackDelay = 0.0f;
    private int enemyLayerMask;

    //hit box
    private int attackRangeX = 2;
    private int attackRangeY = 1;
    public Transform attackPos;

    //anim change reset
    private int animCount = -1;
    private float resetTime = 1.0f;
    private float resetCounter = 0.0f;
    private bool isComboReset = false;

    //dependencies
    private PlayerAnimationManager animManagerRef;
    private PlayerMovement movementRef;
    StatsComponent playerStats;

    private void Start()
    {
        animManagerRef = GetComponent<PlayerAnimationManager>();
        movementRef = GetComponent<PlayerMovement>();
        enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
        playerStats = GetComponent<StatsComponent>();
        attackPos = this.transform.GetChild(0).transform;
    }

    private void Update()
    {
        //space Atatck key pressed?

        if (movementRef.IsGrounded()) // can only do this when grounded
        {
            if (Input.GetMouseButtonDown(0))
            {
                isAttackPressed = true;
            }

            //attack
            if (isAttackPressed)
            {
                resetCounter = 0.0f;
                isComboReset = false;

                isAttackPressed = false;
                if (!isAttacking)
                {
                    isAttacking = true;
                    animCount++;

                    if (animCount == 0)
                        animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_ATTACK);
                    else if (animCount == 1)
                        animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_ATTACK2);
                    else if (animCount == 2)
                    {
                        animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_ATTACK3);
                        animCount = -1;
                    }

                    attackDelay = animManagerRef.GetAnimator().GetCurrentAnimatorStateInfo(0).length * 0.68f;
                    Invoke("AttackComplete", attackDelay);
                }
            }
            else
            {
                if (isComboReset == false)
                {
                    if (resetCounter < resetTime)
                        resetCounter += Time.deltaTime;
                    else
                        isComboReset = true;
                }
            }

            if(isComboReset)
            {
                animCount = -1;
            }
        }
    }

    private void AttackComplete()
    {
        isAttacking = false;
        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemyLayerMask);
        if(enemiesHit != null)
        {
            for(int i = 0; i < enemiesHit.Length; i++)
            {
                //Put Sound


                //first attempt on knockback

                Rigidbody2D enemyRB = enemiesHit[i].GetComponent<Rigidbody2D>();
                //enemyRB.velocity = new Vector2(0, 0);
                enemyRB.AddForce(new Vector2(850.0f, 5.0f), ForceMode2D.Impulse);
                Debug.Log(enemiesHit[i].name);

                enemiesHit[i].GetComponent<Mask>().TakeDamage(playerStats.Power.Value);
               
            }
        }
    }


    public bool IsAttacking()
    {
        return this.isAttacking;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1.0f));
    }


}
