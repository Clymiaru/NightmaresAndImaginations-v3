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
   
    private int groundMask;
    private int platformMask;

    private bool isGrounded;
  

    private PlayerAnimationManager animManagerRef;
    private PlayerCombat combatRef;
    private Dash dashRef;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        platformMask = 1 << LayerMask.NameToLayer("Platform");
        animManagerRef = GetComponent<PlayerAnimationManager>();
        combatRef = GetComponent<PlayerCombat>();
        dashRef = GetComponent<Dash>();
    }

    
    void Update()
    {
        //Checking for inputs
        xAxis = 0;

        if ((combatRef.IsAttacking() && !this.IsGrounded()) || !combatRef.IsAttacking())
            xAxis = Input.GetAxisRaw("Horizontal");

        if(this.IsGrounded() && !combatRef.IsAttacking() && !dashRef.IsDashing())
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
        if(!dashRef.IsDashing())
            rb2d.velocity = vel;
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

    public float GetHorizontalAxis()
    {
        return this.xAxis;
    }

    


}
