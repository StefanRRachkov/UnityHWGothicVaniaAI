using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICrouchState : StateMachineBehaviour
{
    private float rand;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.value;
        if (rand <= 0.5f)
        {
            animator.GetComponent<Health>().bDodge = true;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // TODO: Logic under the Crouching dodge
        
        rand = Random.value;
        if (rand <= 0.2f)
        {
            animator.SetTrigger("ShouldCrouchKick");
        }
        else if (rand <= 0.4f)
        {
            animator.SetBool("ShouldCrouch", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Health>().bDodge = false;
    }
}
