using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public Rigidbody2D rb;
    public Animator animator;

    public Transform headPoint;
    public LayerMask groundLayers;
    Collider2D[] hitHeadGround;

    float lastMove = 0.0f;
    float colliderRadius = 0.9f;
    float movement;
    Vector2 wew;

    int maxJumps = 3;
    int jumps = 0;


    bool canMove = true;


    private void Start()
    {
        this.jumps = this.maxJumps;
        rb = this.GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Missing Rigidbody2D in 'PlayerMovement' script!");
    }


    private void Update()
    {
        this.MovePlayer();
        this.Jump();
       
    }

  
    private void MovePlayer()
    {
        if(this.canMove)
        {
            this.movement = Input.GetAxisRaw("Horizontal");

            if (this.movement != 0)
                this.lastMove = this.movement;
        }
        else if (this.rb.velocity.y == 0.0)
        {
            this.movement = 0.0f;
        }

       
        this.transform.position += new Vector3(this.movement, 0, 0) * Time.deltaTime * this.moveSpeed;



        animator.SetFloat("Horizontal", this.movement);
        animator.SetFloat("Speed", movement * movement);
    }

    private void Jump()
    {
        //Jumping
        if (Input.GetButtonDown("Jump") && this.jumps > 0)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
            this.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            this.jumps--;
        }
        else if (this.rb.velocity.y == 0.0f)
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
            Collider2D[] temp = Physics2D.OverlapCircleAll(this.headPoint.position, this.colliderRadius, this.groundLayers);
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
    }


    public float GetAttackDirection()
    {
        return this.lastMove;
    }

    public void SetMovement(bool move)
    {
        this.canMove = move;
    }
}
