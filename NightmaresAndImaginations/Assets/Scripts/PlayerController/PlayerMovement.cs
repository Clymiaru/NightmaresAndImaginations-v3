using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private StatsComponent playerStats;

    //general movement
    bool canMove = true;
    float lastMove = 1.0f;

    //wall collision
    public Transform headPoint;
    public LayerMask platformLayers;
    Collider2D[] hitHeadGround;
    float colliderRadius = 0.9f;
    float movement = 0.0f;


    //ground check
    public Transform groundCheck;
    public LayerMask groundLayers;
    float groundCheckRadius = 0.5f;


    //jumping
    int maxJumps = 2;
    int jumps = 0;
    private float jumpForce = 15f;

    //dashing
    private float dashTime = 0.2f;
    private float dashForce = 15.0f;
    private float dashCDTimeCounter = 0.0f;
    private float dashCoolDown = 1.0f;
    private bool canDash = true;
    private bool isDashing = false;
    

    private void Start()
    {
        this.jumps = this.maxJumps;
        rb = this.GetComponent<Rigidbody2D>();

        this.playerStats = this.GetComponent<StatsComponent>();

        if (rb == null)
            Debug.LogError("Missing Rigidbody2D in 'PlayerMovement' script!");
    }


    private void FixedUpdate()
    {
        if(!this.isDashing)
            this.rb.velocity = new Vector2(this.movement * this.playerStats.Speed.Value, rb.velocity.y);
    }

    private void Update()
    {
        this.JumpInput();
        this.MoveInput();
        this.DashInput();
        this.UpdateAnimations();
    }


    public bool GroundCheck()
    {
        Collider2D[] platformCheck = Physics2D.OverlapCircleAll(this.groundCheck.position, this.groundCheckRadius, this.platformLayers);
        Collider2D[] groundCheck = Physics2D.OverlapCircleAll(this.groundCheck.position, this.groundCheckRadius, this.groundLayers);

        if (platformCheck.Length != 0 || groundCheck.Length != 0)
            return true;

        return false;
    }

    private void UpdateAnimations()
    {
        if (this.movement != 0)
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);

        //attacking, moving, dashing, idle
        animator.SetFloat("InputDirection", this.GetAttackDirection());
        animator.SetFloat("IdleDirection", this.lastMove);

        //jumping
        if(this.GroundCheck() == true && this.rb.velocity.y > 0)
            animator.SetFloat("YVelocity", 0.0f);
        else
            animator.SetFloat("YVelocity", this.rb.velocity.y);
    }

    private void DashInput()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3"))// left shift is Fire3 for some reason
        {
            //Debug.Log("Right Click or Left Shift");
            if (this.canDash == true)
            {
                //Debug.Log("can Dash!");
                this.canDash = false;
                StartCoroutine(Dash());
                
                animator.SetTrigger("Dash");  
            }
           
        }

        if(this.canDash == false && this.dashCDTimeCounter < this.dashCoolDown)
        {
            this.dashCDTimeCounter += Time.deltaTime;
        }
        else
        {
            this.canDash = true;
            this.dashCDTimeCounter = 0.0f;
        }

    }
  
    IEnumerator Dash()
    {
        float gravityScale = this.rb.gravityScale;
        this.isDashing = true;
        this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
        this.rb.AddForce(new Vector2(this.dashForce * this.lastMove, 0), ForceMode2D.Impulse);
        this.rb.gravityScale = 0.0f;
        yield return new WaitForSeconds(this.dashTime);
        this.isDashing = false;
        this.rb.gravityScale = gravityScale;
    }

    private void MoveInput()
    {
        if(this.canMove)
        {
            this.movement = Input.GetAxisRaw("Horizontal");

            if (this.movement != 0)
            {
                this.lastMove = this.movement;
                
            }
                
        }
        else if (this.rb.velocity.y == 0.0)
        {
            this.movement = 0.0f;
        }
    }

    private void JumpInput()
    {
        //Jumping
        if (Input.GetButtonDown("Jump") && this.jumps > 0)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
            this.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            this.jumps--;
        }
        else if (this.rb.velocity.y == 0.0f && this.GroundCheck() == true)
            this.jumps = this.maxJumps;

        //Make player go through ground when jumping
        if (this.rb.velocity.y > 0.0)
        {
            if(this.hitHeadGround != null)
            {
                for (int i = 0; i < this.hitHeadGround.Length; i++)
                {
                    this.hitHeadGround[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            Collider2D[] temp = Physics2D.OverlapCircleAll(this.headPoint.position, this.colliderRadius, this.platformLayers);
            if(temp != null)
                this.hitHeadGround = temp;

            for (int i = 0; i < this.hitHeadGround.Length; i++)
            {
                this.hitHeadGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.headPoint.position, this.colliderRadius);
        Gizmos.DrawWireSphere(this.groundCheck.position, this.groundCheckRadius);
    }


    public float GetAttackDirection()
    {
        if (this.movement != 0)
            return this.movement;

        return this.lastMove;
    }

    public void SetMovement(bool move)
    {
        this.canMove = move;
        
    }


    

}
