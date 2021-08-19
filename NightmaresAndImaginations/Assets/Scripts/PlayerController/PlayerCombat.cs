using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private PlayerMovement movementRef;

    private float attackCD = 0.2f;
    private float attackTimeCounter = 0.0f;
    private bool canAttack = true;

    Vector2 attackRange;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        this.movementRef = this.GetComponent<PlayerMovement>();
        if (this.movementRef == null)
            Debug.LogError("Script PlayerCombat: no reference to PlayerMovement component!");

        this.attackRange = new Vector2(0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
       if (Input.GetMouseButtonDown(0) && this.movementRef.GroundCheck() == true)
       {
           if (this.canAttack)
           {
                this.canAttack = false;
                Attack();
           }
             
       }

       if (this.canAttack == false && this.attackTimeCounter < this.attackCD)
       {
            this.attackTimeCounter += Time.deltaTime;
       }
       else
       {
            this.canAttack = true;
            this.attackTimeCounter = 0.0f;
       }

       if(this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
       {
            this.movementRef.SetMovement(false);
       }
       else
       {
            this.movementRef.SetMovement(true);
        }

    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = null; ;
        

        if (this.movementRef.GetAttackDirection() == 0)
            hitEnemies = Physics2D.OverlapBoxAll(this.attackPointLeft.position, this.attackRange, this.enemyLayers);
        else if(this.movementRef.GetAttackDirection() > 0)
            hitEnemies = Physics2D.OverlapBoxAll(this.attackPointRight.position, this.attackRange, this.enemyLayers);
        else if (this.movementRef.GetAttackDirection() < 0)
            hitEnemies = Physics2D.OverlapBoxAll(this.attackPointLeft.position, this.attackRange, this.enemyLayers);

        if (hitEnemies != null)
        {
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                Debug.Log("Hit enemy " + hitEnemies[i].name);
                
                //do damage calculation here
                var mask = hitEnemies[i].GetComponent<Mask>();
                var playerStats = gameObject.GetComponent<StatsComponent>();
                if (mask != null)
                    hitEnemies[i].GetComponent<Mask>().TakeDamage(playerStats.Power.Value);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(this.attackPointRight.position, this.attackRange * 2.0f);
        Gizmos.DrawWireCube(this.attackPointLeft.position, this.attackRange * 2.0f);
    }
}
