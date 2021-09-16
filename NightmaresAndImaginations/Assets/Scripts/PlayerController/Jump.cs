using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isJumpPressed;
    private Rigidbody2D rb2d;
    private float jumpForce;
    private int currentJumpCount;
    private int maxJump;

    private PlayerAnimationManager animManagerRef;
    private PlayerMovement movementRef;
    private PlungeAttack plungeAttackRef;

    int platformMask;
    RaycastHit2D platformHit;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 15.0f;
        maxJump = 2;
        currentJumpCount = maxJump;

        rb2d = GetComponent<Rigidbody2D>();
        animManagerRef = GetComponent<PlayerAnimationManager>();
        movementRef = GetComponent<PlayerMovement>();
        plungeAttackRef = GetComponent<PlungeAttack>();

        platformMask = 1 << LayerMask.NameToLayer("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        //Check if trying to jump 
        if (isJumpPressed && currentJumpCount > 0 && !plungeAttackRef.IsPlungeAttack())
        {
            //Put Sound


            rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            currentJumpCount--;
            isJumpPressed = false;
        }

        //disable platforms when jumping from below them
        if (this.rb2d.velocity.y > 0.0)
        {
            if(platformHit.collider != null)
                platformHit.collider.GetComponent<BoxCollider2D>().enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.up, 1.0f, this.platformMask);
            platformHit = hit;

            if (platformHit.collider != null)
            {
                platformHit.collider.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        

        if (movementRef.IsGrounded())
        {
            currentJumpCount = maxJump;
        }
        else if(!movementRef.IsGrounded())
        {
            if (rb2d.velocity.y > 0)
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_JUMP);
            else if (rb2d.velocity.y < -1.0f && !plungeAttackRef.IsPlungeAttack())
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_JUMP_FALL);
        }
       
    }


    public void SetMaxJumps(int numJumps)
    {
        this.maxJump = numJumps;
    }
}
