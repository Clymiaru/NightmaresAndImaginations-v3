using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{

    PlayerResponse playerResponseRef;
    int damage = 999;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (playerResponseRef == null)
                playerResponseRef = collision.gameObject.GetComponent<PlayerResponse>();

            playerResponseRef.TakeDamage(damage, transform.position.x);
        }
    }
}
