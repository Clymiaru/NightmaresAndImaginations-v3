using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TDS;


public class SwordProjectileBehavior : MonoBehaviour
{
    private Animator animator;
    private int swordState = 0;
    private float travelSpeed = 15.0f;

    private Rigidbody2D rb2d;

    private float lifeTime = 10.0f;
    private float timer = 0.0f;
    private bool hasCountDownStarted = false;

    private BoxCollider2D swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        swordCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(swordState == 0)
        {
            animator.Play("SwordSpawn");

            if(IsDonePlayingCurrentAnimation())
            {
                swordState++;
            }
        }
        else if(swordState == 1)
        {
            animator.Play("SwordTravel");
            rb2d.velocity = new Vector2(travelSpeed * rb2d.transform.localScale.x, 0);
            swordState++;
            hasCountDownStarted = true;
        }

        if(hasCountDownStarted == true)
        {
            if(timer < lifeTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SwordHit();
            }
        }

    }

    private void SwordHit()
    {
        swordCollider.enabled = false;
        animator.Play("SwordHit");
        float animTime = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("DestroySword", animTime);
    }

    private void DestroySword()
    {
        Destroy(gameObject);
    }

    private bool IsDonePlayingCurrentAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);

        if (collision.GetComponent<Mask>() != null)
        {
            collision.GetComponent<Mask>().TakeDamage(10);
        }

        if(collision.gameObject.name != "Player")
        {
            rb2d.velocity = new Vector2(0, 0);
            SwordHit();
        }

    }
    
    
}
