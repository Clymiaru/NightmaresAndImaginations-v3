using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing = false;
    private float dashForce = 15.0f;
    private Rigidbody2D rb2d;
    private float dashTime = 0.15f;


    private float dashCDTimeCounter = 0.0f;
    private float dashCoolDown = 1.0f;

    private PlayerAnimationManager animManagerRef;
    private PlungeAttack plungeAttackRef;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animManagerRef = GetComponent<PlayerAnimationManager>();
        plungeAttackRef = GetComponent<PlungeAttack>();
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3"))// left shift is Fire3 for some reason
        {
            
            //Debug.Log("Right Click or Left Shift");
            if (this.canDash == true && !plungeAttackRef.IsPlungeAttack())
            {
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
        this.isDashing = true;
        this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
        this.rb2d.AddForce(new Vector2(this.dashForce * transform.localScale.x, 0), ForceMode2D.Impulse);
        this.rb2d.gravityScale = 0.0f;
        yield return new WaitForSeconds(this.dashTime);
        this.isDashing = false;
        this.rb2d.gravityScale = gravityScale;
    }


    public bool IsDashing()
    {
        return this.isDashing;
    }

}
