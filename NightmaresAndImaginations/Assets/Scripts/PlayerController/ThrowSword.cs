using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSword : MonoBehaviour
{
    private AudioManager audioManagerRef;
    bool isPressed = false;
    bool canThrow = true;
    float abilityCD = 3.0f;
    float cdCounter = 0.0f;

    public Transform spawnPoint;
    public GameObject sword;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        if (audioManagerRef == null)
        {
            audioManagerRef = GameObject.FindObjectOfType<AudioManager>();
            audioManagerRef = audioManagerRef.GetComponent<AudioManager>();
        }

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canThrow)
        {
            isPressed = true;
        }

        if (isPressed && canThrow)
        {
            isPressed = false;
            canThrow = false;
            this.SpawnSword();
        }


        if(!canThrow && cdCounter < abilityCD)
        {
            cdCounter += Time.deltaTime;
        }
        else
        {
            canThrow = true;
            cdCounter = 0.0f;
        }

    }

    private void SpawnSword()
    {
        audioManagerRef.Play(AudioManager.SHOOT_SFX);
        sword.transform.localScale = rb2d.transform.localScale;
        Instantiate(sword, spawnPoint.position, Quaternion.identity);
    }

}
