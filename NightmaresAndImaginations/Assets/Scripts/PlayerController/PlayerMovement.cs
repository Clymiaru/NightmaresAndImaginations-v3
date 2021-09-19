using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5f;

    private float xAxis;
    private Rigidbody2D rb2d;

    private PlayerAnimationManager animManagerRef;
    private PlayerStatsManager playerRef;


    void Start()
    {
        animManagerRef = GetComponent<PlayerAnimationManager>();
        playerRef = GetComponent<PlayerStatsManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Checking for inputs
        xAxis = 0;

        if ((playerRef.IsAttacking() && !playerRef.IsGrounded() && !playerRef.IsTakingDamage()&& !playerRef.IsTakingDamage()) || !playerRef.IsAttacking())
            xAxis = Input.GetAxisRaw("Horizontal");

        if(playerRef.IsGrounded() && !playerRef.IsAttacking() && !playerRef.IsDashing() && !playerRef.IsTakingDamage())
        {
            if (xAxis != 0)
            {
                //Debug.Log("Run");
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_RUN);
            }
            else
            {
                //Debug.Log("Idle");
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_IDLE);
            }
        } 
        
    }

    private void FixedUpdate()
    {
        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);
       
        if(!playerRef.IsDashing())
        {
            if (xAxis < 0)
            {
                vel.x = -walkSpeed;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (xAxis > 0)
            {
                vel.x = walkSpeed;
                transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                vel.x = 0;

            }


            //assign the new velocity to the rigidbody
            if (!playerRef.IsTakingDamage())
                rb2d.velocity = vel;
        }   
    }

   
    public float GetHorizontalAxis()
    {
        return this.xAxis;
    }

}
