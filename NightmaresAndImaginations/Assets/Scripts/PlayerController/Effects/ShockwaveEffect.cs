using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveEffect : MonoBehaviour
{
    private Animator animator;
    private bool hasRunOnce = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasRunOnce)
        {
            animator.Play("ShockWave");
            float animTime = animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("DestroyObject", animTime);
            hasRunOnce = true;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
