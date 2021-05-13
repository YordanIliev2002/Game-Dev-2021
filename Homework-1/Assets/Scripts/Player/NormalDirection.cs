using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDirection : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<SpriteRenderer>().flipX = false;
    }
}
