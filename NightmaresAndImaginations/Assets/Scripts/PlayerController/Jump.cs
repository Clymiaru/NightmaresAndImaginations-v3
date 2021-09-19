using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private AudioManager audioManagerRef;
    private bool isJumpPressed;
    private Rigidbody2D rb2d;
    private float jumpForce;
    private int currentJumpCount;
    private int maxJump;

    private PlayerAnimationManager animManagerRef;
    private PlayerStatsManager playerRef;
    private PlungeAttack plungeAttackRef;

    int platformMask;
    RaycastHit2D platformHit;

    // Start is called before the first frame update
    void Start()
    {
        if (audioManagerRef == null)
        {
            audioManagerRef = GameObject.FindObjectOfType<AudioManager>();
            audioManagerRef = audioManagerRef.GetComponent<AudioManager>();
        }

        currentJumpCount = maxJump;
        jumpForce = 15.0f;
        maxJump = 2;

        plungeAttackRef = GetComponent<PlungeAttack>();
        animManagerRef = GetComponent<PlayerAnimationManager>();
        playerRef = GetComponent<PlayerStatsManager>();
        rb2d = GetComponent<Rigidbody2D>();

        platformMask = 1 << LayerMask.NameToLayer("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount > 0)
        {
            isJumpPressed = true;
        }

        //Check if trying to jump 
        if (isJumpPressed && currentJumpCount > 0 && !playerRef.IsPlungeAttacking() && !playerRef.IsTakingDamage())
        {
            //Put Sound
            audioManagerRef.Play(AudioManager.JUMP_SFX);

            isJumpPressed = false;
            rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            currentJumpCount--;
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
        

        if (playerRef.IsGrounded() && this.rb2d.velocity.y <= 0.0)
        {
            currentJumpCount = maxJump;
        }
        else if(!playerRef.IsGrounded())
        {
            if (rb2d.velocity.y > 0)
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_JUMP);
            else if (rb2d.velocity.y < -1.0f && !playerRef.IsPlungeAttacking())
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_JUMP_FALL);
        }
       
    }


    public void SetMaxJumps(int numJumps)
    {
        this.maxJump = numJumps;
    }
}
