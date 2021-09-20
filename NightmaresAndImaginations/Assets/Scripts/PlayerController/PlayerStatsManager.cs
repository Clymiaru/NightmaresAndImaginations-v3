using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TDS;

public class PlayerStatsManager : MonoBehaviour
{
    //is grounded
    private int groundMask;
    private int platformMask;
    private bool isGrounded;

    //is plunge attacking
    private bool isPlungeAttacking = false;
    private bool canPlungeAttack = true;

    //grounded attack combo
    private bool isAttacking = false;

    //dash
    private bool isDashing = false;
    private bool canDash = true;

    //player responses
    private bool isTakingDamage = false;
    private bool canTakeDamage = true;

    //throw sword
    bool canThrow = true;


    // Start is called before the first frame update
    void Start()
    {
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        platformMask = 1 << LayerMask.NameToLayer("Platform");
    }

    public bool IsGrounded()
    {
        //check if player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.2f, this.groundMask);
        RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Vector2.down, 1.2f, this.platformMask);

        if (hit.collider != null || hit2.collider != null)
        {
            //Debug.Log("Grounded!");
            isGrounded = true;
        }
        else
        {
            //Debug.Log("Not Grounded!");
            isGrounded = false;
        }

        return this.isGrounded;
    }

    public bool IsPlungeAttacking()
    {
        return this.isPlungeAttacking;
    }
    public void IsPlungeAttacking(bool isPlungeattacking)
    {
        this.isPlungeAttacking = isPlungeattacking;
    }
    public bool CanPlungeAttack()
    {
        return this.canPlungeAttack;
    }
    public void CanPlungeAttack(bool canPlungeAttack)
    {
        this.canPlungeAttack = canPlungeAttack;
    }


    public bool IsAttacking()
    {
        return this.isAttacking;
    }
    public void IsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }

    public bool IsDashing()
    {
        return this.isDashing;
    }
    public void IsDashing(bool isDashing)
    {
        this.isDashing = isDashing;
    }
    public bool CanDash()
    {
        return canDash;
    }
    public void CanDash(bool canDash)
    {
        this.canDash =  canDash;
    }

    public bool IsTakingDamage()
    {
        return this.isTakingDamage;
    }
    public void IsTakingDamage(bool isTakingDamage)
    {
        this.isTakingDamage = isTakingDamage;
    }

    public bool CanTakeDamage()
    {
        return this.canTakeDamage;
    }
    public void CanTakeDamage(bool canTakeDamage)
    {
       this.canTakeDamage = canTakeDamage;
    }


    public bool CanThrow()
    {
        return canThrow;
    }
    public void CanThrow(bool canThrow)
    {
        this.canThrow = canThrow;
    }
}
