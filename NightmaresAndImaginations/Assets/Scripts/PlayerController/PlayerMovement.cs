using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public Rigidbody2D rb;
    public Animator animator;

    float movement;
    Vector2 wew;

    int maxJumps = 3;
    int jumps = 0;


    private void Start()
    {
        this.jumps = this.maxJumps;

        rb = this.GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Missing Rigidbody2D in 'PlayerMovement' script!");
    }


    private void Update()
    {
        this.movement = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", this.movement);
        animator.SetFloat("Speed", movement * movement);

        this.transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * this.moveSpeed;

        if (Input.GetButtonDown("Jump") && this.jumps > 0)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
            this.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            this.jumps--;
        }
        else if (this.rb.velocity.y == 0.0f)
            this.jumps = this.maxJumps;
    }

  
}
