using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObjects : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [SerializeField] private float cd = 1.0f;
    float cdTimer = 0.0f;

    private bool isPlayerIn = false;
    private bool canDamage = true;

    PlayerResponse playerResponseRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canDamage && cdTimer < cd)
            cdTimer += Time.deltaTime;
        else
        {
            cdTimer = 0.0f;
            canDamage = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(canDamage && isPlayerIn)
        {
            canDamage = false;
            playerResponseRef.TakeDamage(damage, transform.position.x);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isPlayerIn = true;
            if (playerResponseRef == null)
                playerResponseRef = collision.gameObject.GetComponent<PlayerResponse>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isPlayerIn = false;
        }
    }


}
