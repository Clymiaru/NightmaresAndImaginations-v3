using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBush : MonoBehaviour
{
    private Animator animatorBush;
    public GameObject gameObj;
    [SerializeField] private bool isInsideCollider = false;

    private void Start()
    {
        animatorBush = gameObj.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInsideCollider && gameObj.name == "AttackBush")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Trigger Animation of Attacked Bush");
                // Animate once
                animatorBush.Play("Bush");
            }

            else if (Input.GetMouseButtonUp(0))
            {
                animatorBush.Play("Idle");
            }
        }

        else
        {
            animatorBush.Play("Idle");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.isInsideCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.isInsideCollider = false;
    }
}
