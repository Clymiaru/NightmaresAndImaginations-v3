using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private PlayerMovement movementRef;

    public float attackRate = 2.0f;
    private float nextAttackTime = 0.0f;

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

        this.attackRange = new Vector2(1.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >=  this.nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && this.movementRef.GroundCheck() == true)
            {
                Attack();
                nextAttackTime = Time.time + 1f / this.attackRate;
            }    
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
                hitEnemies[i].GetComponent<Mask>().TakeDamage(10);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(this.attackPointRight.position, this.attackRange);
        Gizmos.DrawWireCube(this.attackPointLeft.position, this.attackRange);
    }
}
