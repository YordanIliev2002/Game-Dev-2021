using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippedDirection : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<SpriteRenderer>().flipX = true;
    }
}
