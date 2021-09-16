using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlungeAttack : MonoBehaviour
{
    PlayerMovement movementRef;
    Rigidbody2D rb2d;
    PlayerAnimationManager animManagerRef;
    StatsComponent playerStats;

    //plunge attack physics
    float dropDownForce = -20.0f;
    bool isPlungeAttacking = false;

    public Transform attackPos;
    private int attackRangeX = 4;
    private int attackRangeY = 1;
    private int enemyLayerMask;

    private Transform attackEffectSpawnPoint;
    public GameObject shockWave;

    private void Start()
    {
        movementRef = this.GetComponent<PlayerMovement>();
        rb2d = this.GetComponent<Rigidbody2D>();
        animManagerRef = this.GetComponent<PlayerAnimationManager>();
        attackPos = this.transform.GetChild(1).transform;
        enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
        playerStats = GetComponent<StatsComponent>();
        attackEffectSpawnPoint = this.transform.GetChild(3).transform;
    }


    private void Update()
    {
        if (this.movementRef.IsGrounded() == false)
        {
            if(Input.GetMouseButtonDown(0) && this.isPlungeAttacking == false)
            {
                //Put Sound

                this.rb2d.velocity = new Vector2(0, 0);
                this.rb2d.AddForce(new Vector2(0, this.dropDownForce), ForceMode2D.Impulse);
                this.isPlungeAttacking = true;
                
            }
        }

        if(this.isPlungeAttacking == true)
        {
            animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_AIR_ATTACK);
            if (this.movementRef.IsGrounded() == true)
            {
                GameObject temp = Instantiate(shockWave, attackEffectSpawnPoint.position, Quaternion.identity);
                //temp.transform.parent = gameObject.transform;

                this.DamageEnemies();
                this.isPlungeAttacking = false;
            }
        }
    }

    private void DamageEnemies()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemyLayerMask);
        if (enemiesHit != null)
        {
            for (int i = 0; i < enemiesHit.Length; i++)
            {
                //Put Sound


                //first attempt on knockback

                /*Rigidbody2D enemyRB = enemiesHit[i].GetComponent<Rigidbody2D>();
                enemyRB.velocity = new Vector2(0, 0);
                enemyRB.AddForce(new Vector2(85.0f, 5.0f), ForceMode2D.Impulse);
                Debug.Log(enemiesHit[i].name);*/
                enemiesHit[i].GetComponent<Mask>().TakeDamage(playerStats.Power.Value);
            }
        }
    }

    public bool IsPlungeAttack()
    {
        return this.isPlungeAttacking;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1.0f));
    }

}
