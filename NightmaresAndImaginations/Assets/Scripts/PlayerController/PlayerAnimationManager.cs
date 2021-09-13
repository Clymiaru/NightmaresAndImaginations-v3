using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator animator;
    private string currentState;


    //Animation states
    public const string PLAYER_PLUNGE_FALLING = "Player_PlungeFall_Right";


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) // to stop the animation from interrupting itself
            return;

        animator.Play(newState); // play the animation


        currentState = newState; // set current state to new state
    }
}
