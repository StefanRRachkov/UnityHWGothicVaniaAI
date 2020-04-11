using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controlls;

public class MonkCrouchState : StateMachineBehaviour
{

    private MovementController movementController;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movementController = animator.GetComponent<MovementController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(attackKey))
        {
            animator.SetTrigger("IsCrouchKicking");
        }
        if (Input.GetKeyUp(crouchKey))
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsPunching");
        animator.ResetTrigger("IsCrouchKicking");
    }
}
