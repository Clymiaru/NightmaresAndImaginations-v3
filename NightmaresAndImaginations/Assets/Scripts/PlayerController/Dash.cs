using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    private float dashForce = 15.0f;
    private Rigidbody2D rb2d;
    private float dashTime = 0.2f;


    private float dashCDTimeCounter = 0.0f;
    private float dashCoolDown = 1.0f;

    private PlayerAnimationManager animManagerRef;
    private PlayerStatsManager playerRef;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animManagerRef = GetComponent<PlayerAnimationManager>();
        playerRef = GetComponent<PlayerStatsManager>();
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3"))// left shift is Fire3 for some reason
        {
            
            //Debug.Log("Right Click or Left Shift");
            if (this.canDash == true && !playerRef.IsPlungeAttacking() && !playerRef.IsTakingDamage())
            {
                //Put Sound


                //Debug.Log("Dash!");
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_DASH);
                this.canDash = false;
                StartCoroutine(Dashing());
            }

        }


        if (this.canDash == false && this.dashCDTimeCounter < this.dashCoolDown)
        {
            this.dashCDTimeCounter += Time.deltaTime;
        }
        else
        {
            this.canDash = true;
            this.dashCDTimeCounter = 0.0f;
        }

    }

    IEnumerator Dashing()
    {
        float gravityScale = this.rb2d.gravityScale;
        this.playerRef.IsDashing(true);
        this.playerRef.CanTakeDamage(false);
        this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
        this.rb2d.AddForce(new Vector2(this.dashForce * transform.localScale.x, 0), ForceMode2D.Impulse);
        this.rb2d.gravityScale = 0.0f;
        yield return new WaitForSeconds(this.dashTime);

        //after dash
        this.playerRef.IsDashing(false);
        this.playerRef.CanTakeDamage(true);
        this.rb2d.gravityScale = gravityScale;
    }


}
