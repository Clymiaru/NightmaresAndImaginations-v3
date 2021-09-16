using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBush : MonoBehaviour
{
    private Animator animatorBush;
    public GameObject gameObj;
    [SerializeField] private bool isInsideCollider = false;
    private int counter = 0;

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
                // Animate
                animatorBush.Play("Bush");
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
