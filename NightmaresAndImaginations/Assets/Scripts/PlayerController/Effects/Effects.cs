using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private Animator animator;
    private bool hasRunOnce = false;

    private const string SHOCK_WAVE_EFFECT = "GroundPoundEffect(Clone)";
    private const string HEAL_EFFECT = "HealParticleEffect(Clone)";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasRunOnce)
        {
            float animTime = 0.0f;

            if(gameObject.name == SHOCK_WAVE_EFFECT)
            {
                animator.Play("Shock_Wave");
                animTime = animator.GetCurrentAnimatorStateInfo(0).length * 0.5f;
            }
            else if(gameObject.name == HEAL_EFFECT)
            {
                animator.Play("Heal_Particles");
                animTime = animator.GetCurrentAnimatorStateInfo(0).length;
            }


            Invoke("DestroyObject", animTime);
            hasRunOnce = true;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
