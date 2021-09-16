using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungeAttack : MonoBehaviour
{
    /*PlayerMovement movementRef;
    Rigidbody2D rb;
    PlayerAnimationManager playerAnimRef;
    Animator animator;

    //plunge attack physics
    float dropDownForce = -20.0f;
    bool isPlungeAttacking = false;

    private void Start()
    {
        movementRef = this.GetComponent<PlayerMovement>();
        rb = this.GetComponent<Rigidbody2D>();
        playerAnimRef = this.GetComponent<PlayerAnimationManager>();
        animator = this.GetComponent<Animator>();
    }


    private void Update()
    {
        //Debug.Log(this.movementRef.canMove);
        //Debug.Log(this.isPlungeAttacking);


        if (this.movementRef.GroundCheck() == false)
        {
            if(Input.GetMouseButtonDown(0) && this.isPlungeAttacking == false)
            {
                this.movementRef.SetMovement(false);
                this.rb.velocity = new Vector2(0, 0);
                this.rb.AddForce(new Vector2(0, this.dropDownForce), ForceMode2D.Impulse);
                this.isPlungeAttacking = true;
                
            }
        }

        if(this.isPlungeAttacking == true)
        {
            this.animator.SetTrigger("PlungeAttack");

            Debug.Log("PlungeAttacking!!");
            if (this.movementRef.GroundCheck() == true)
            {
                this.movementRef.SetMovement(true);
                this.isPlungeAttacking = false;
            }
        }
    }

    public bool IsPlungeAttack()
    {
        return this.isPlungeAttacking;
    }*/

}
