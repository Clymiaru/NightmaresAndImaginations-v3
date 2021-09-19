using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TDS;

public class FountainBehavior : MonoBehaviour
{
    Animator animator;

    private float cd = 30.0f;
    private float cdTimer = 0.0f;

    private bool canUse = true;
    private bool isUsing = false;
    private bool triggerRefilling = false;
    private bool isRefilling = false;

    private bool isColliding = false;
    private bool isPlayer = false;


    private Transform effectSpawnPoint;
    public GameObject healEffect;

    private StatsComponent playerStats;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
      
        //update fountain anim
        if (canUse && !isUsing)
        {
            animator.Play("Fountain_Idle");
        }

        //cd
        if (!canUse && cdTimer < cd)
        {
            //if()
            animator.Play("Fountain_Empty");
            cdTimer += Time.deltaTime;
        }
        else if (cdTimer >= cd)
        {
            triggerRefilling = true;
        }
        
             

        if (triggerRefilling)
        {
            isRefilling = true;
            triggerRefilling = false;
            //Debug.Log("Fountain_Refill");
            animator.Play("Fountain_Refill");
            InvokeFunctionWithDelay("RefillFountain");
        }
        


        //get input
        if (Input.GetKeyDown(KeyCode.F) && canUse && isPlayer && isColliding)
        {
            isUsing = true;
            animator.Play("Fountain_Use");
            InvokeFunctionWithDelay("UseFountain");
        }

    }

    private void InvokeFunctionWithDelay(string name)
    {
        float delayTime = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke(name, delayTime);
    }


    private void UseFountain()
    {
        canUse = false;
        isUsing = false;

        Vector3 tempPos = effectSpawnPoint.position;
        //offset 
        tempPos.x -= 0.2939f;
        tempPos.y += 1.133f;
        Instantiate(healEffect, tempPos, Quaternion.identity);
        playerStats.Health.Restore(3);
    }

    private void RefillFountain()
    {
        canUse = true;
        isRefilling = false;
        cdTimer = 0.0f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isColliding = true;
            isPlayer = true;

            if(effectSpawnPoint == null)
                effectSpawnPoint = collision.gameObject.transform.GetChild(3).transform;

            if (playerStats == null)
                playerStats = collision.gameObject.GetComponent<StatsComponent>();
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isColliding = false;
            isPlayer = false;
        }
    }


}
