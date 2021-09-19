using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class PlungeAttack : MonoBehaviour
{
    private AudioManager audioManagerRef;
    PlayerAnimationManager animManagerRef;
    PlayerStatsManager playerRef;
    StatsComponent playerStats;
    Rigidbody2D rb2d;
    
    //plunge attack physics
    float dropDownForce = -20.0f;
    
    //hit box
    public Transform attackPos;
    private int attackRangeX = 4;
    private int attackRangeY = 1;
    private int enemyLayerMask;

    private Transform attackEffectSpawnPoint;
    public GameObject shockWave;


    private float cd = 1.5f;
    private float cdCounter = 0.0f;
    private bool canAttack = true;

    private void Start()
    {
        if (audioManagerRef == null)
        {
            audioManagerRef = GameObject.FindObjectOfType<AudioManager>();
            audioManagerRef = audioManagerRef.GetComponent<AudioManager>();
        }

        animManagerRef = this.GetComponent<PlayerAnimationManager>();
        playerStats = GetComponent<StatsComponent>();
        playerRef = this.GetComponent<PlayerStatsManager>();
        rb2d = this.GetComponent<Rigidbody2D>();
         
        attackEffectSpawnPoint = this.transform.GetChild(3).transform;
        attackPos = this.transform.GetChild(1).transform;

        enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
    }


    private void Update()
    {
        if (!this.playerRef.IsGrounded() && !playerRef.IsTakingDamage() && canAttack)
        {
            if(Input.GetMouseButtonDown(0) && !this.playerRef.IsPlungeAttacking())
            {
                //Put Ground Attack Airtime Sound



                this.playerRef.CanTakeDamage(false);
                this.canAttack = false;
                this.rb2d.velocity = new Vector2(0, 0);
                this.rb2d.AddForce(new Vector2(0, this.dropDownForce), ForceMode2D.Impulse);
                this.playerRef.IsPlungeAttacking(true);
                
            }
        }

        if(this.playerRef.IsPlungeAttacking() == true)
        {
            animManagerRef.ChangeAnimationState(PlayerAnimationManager.PLAYER_AIR_ATTACK);
                
            if (this.playerRef.IsGrounded() == true)
            {
                GameObject temp = Instantiate(shockWave, attackEffectSpawnPoint.position, Quaternion.identity);

                this.DamageEnemies();
                this.playerRef.IsPlungeAttacking(false);
                this.playerRef.CanTakeDamage(true);
            }
        }

        //CD
        if(!canAttack)
        {
            if(cdCounter < cd)
            {
                cdCounter += Time.deltaTime;
            }
            else
            {
                cdCounter = 0.0f;
                canAttack = true;
            }
        }




    }

    private void DamageEnemies()
    {
        // Put Ground Hit Sound
        audioManagerRef.Play(AudioManager.GROUND_ATTACK_SFX);

        Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, enemyLayerMask);
        if (enemiesHit != null)
        {
           

            for (int i = 0; i < enemiesHit.Length; i++)
            {
                //first attempt on knockback

                /*Rigidbody2D enemyRB = enemiesHit[i].GetComponent<Rigidbody2D>();
                enemyRB.velocity = new Vector2(0, 0);
                enemyRB.AddForce(new Vector2(85.0f, 5.0f), ForceMode2D.Impulse);
                Debug.Log(enemiesHit[i].name);*/
                enemiesHit[i].GetComponent<Mask>().TakeDamage(playerStats.Power.Value);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1.0f));
    }

}
