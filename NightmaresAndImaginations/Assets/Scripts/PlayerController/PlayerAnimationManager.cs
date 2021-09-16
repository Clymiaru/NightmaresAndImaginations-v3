using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator animator;
    private string currentState;


    //Animation states
    public const string PLAYER_IDLE = "Player_Idle_Right";
    public const string PLAYER_RUN = "Player_Walk_Right";
    public const string PLAYER_JUMP = "Player_Jump_Right";
    public const string PLAYER_JUMP_FALL = "Player_Fall_Right";
    public const string PLAYER_ATTACK = "Player_Attack_Right";
    public const string PLAYER_AIR_ATTACK = "Player_PlungeFall_Right";
    public const string PLAYER_DASH = "Player_Dash_Right";


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();  
    }


    private void Update()
    {
        Debug.Log(currentState);
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) // to stop the animation from interrupting itself
            return;

        animator.Play(newState); // play the animation


        currentState = newState; // set current state to new state
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
