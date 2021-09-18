using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlayerResponse : MonoBehaviour
{
    private PlayerAnimationManager animManagerRef;
    private PlayerStatsManager playerRef;
    private StatsComponent playerStats;
    private Rigidbody2D rb2d;

    private float knockBackForce = 10.0f;
    private float knockBackTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        animManagerRef = GetComponent<PlayerAnimationManager>();
        playerStats = GetComponent<StatsComponent>();
        playerRef = GetComponent<PlayerStatsManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void TakeDamage(int damage, float directionX)
    {
        if(!this.playerRef.IsTakingDamage() && this.playerRef.CanTakeDamage())
        {
            //cancel attacks when damaged
            playerRef.IsAttacking(false);
            playerRef.IsPlungeAttacking(false);


            this.playerRef.CanTakeDamage(false);
            this.playerRef.IsTakingDamage(true);
            //deal damage calc
            playerStats.Health.TakeDamage(damage, playerStats.Defense.Value);
            
            if (playerStats.IsDead)
            {
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_DEATH);
                float delayTime = animManagerRef.GetAnimator().GetCurrentAnimatorStateInfo(0).length;
                Invoke("Die", delayTime);
            }
                
            else
            {
                animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_TAKE_DAMAGE);
                rb2d.transform.localScale = new Vector3(-directionX, 1, 1);
                StartCoroutine(KnockBack(directionX));
            }
            
        }
    }


    public void Die()
    {
        Behaviour[] components = gameObject.GetComponents<Behaviour>();

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        for (int i = 0; i < components.Length; i++)
        {
            components[i].enabled = false;

        }
    
    }

    IEnumerator KnockBack(float scaleX)
    {
        float gravityScale = this.rb2d.gravityScale;
        this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
        this.rb2d.AddForce(new Vector2(this.knockBackForce * scaleX, 0), ForceMode2D.Impulse);
        this.rb2d.gravityScale = 0.0f;
        yield return new WaitForSeconds(this.knockBackTime);
        this.playerRef.IsTakingDamage(false);
        this.playerRef.CanTakeDamage(true);
        this.rb2d.gravityScale = gravityScale;
        
    }



}
