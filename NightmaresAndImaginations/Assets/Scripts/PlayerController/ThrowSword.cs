using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSword : MonoBehaviour
{
    bool isPressed = false;
    float abilityCD = 3.0f;
    float cdCounter = 0.0f;

    public Transform spawnPoint;
    public GameObject sword;

    private Rigidbody2D rb2d;

    private PlayerStatsManager playerRef;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerRef = GetComponent<PlayerStatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerRef.CanThrow())
        {
            isPressed = true;
        }

        if (isPressed && playerRef.CanThrow())
        {
            isPressed = false;
            playerRef.CanThrow(false);
            this.SpawnSword();
        }


        if(!playerRef.CanThrow() && cdCounter < abilityCD)
        {
            cdCounter += Time.deltaTime;
        }
        else
        {
            playerRef.CanThrow(true);
            cdCounter = 0.0f;
        }

    }

    private void SpawnSword()
    {
        sword.transform.localScale = rb2d.transform.localScale;
        Instantiate(sword, spawnPoint.position, Quaternion.identity);
    }

}
