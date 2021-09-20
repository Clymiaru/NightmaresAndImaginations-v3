using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    private Animator doorAnimator;
    private GameManager gameManager;
    private bool isOpened = false;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (this.gameManager == null)
            Debug.LogError("Script GameManager, gameManager is null!");
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (isOpened)
        {
            doorAnimator.Play("OpenedDoor");
        }
    }

    private void StayOpened()
    {
        isOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player" && !isOpened)
        {
            KeyHolder keyHolder = collider.gameObject.GetComponent<KeyHolder>();
            if (keyHolder.ContainsAllKeys()) // and killed all enemies  (&& gameManager.isAllEnemiesDead)
            {
                doorAnimator.Play("DoorOpen");
                float delayTime = doorAnimator.GetCurrentAnimatorStateInfo(0).length * 0.9f;
                Invoke("StayOpened", delayTime);
                keyHolder.ClearKeyList();
                gameManager.PlayerWin();
            }
        }
    }
}
