using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDust : StateMachineBehaviour
{
    private DustParticleSystem system;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Make sure that dust is emitted only when landing on the gorund
        if(!animator.GetBool("isDead"))
        {
            animator.GetComponent<DustParticleSystem>().Burst();
        }
    }
}
