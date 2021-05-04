using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitDust : StateMachineBehaviour
{
    private DustParticleSystem system;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        system = animator.GetComponent<DustParticleSystem>();
        if(system)
        {
            system.Play();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (system)
        {
            system.Stop();
        }

    }
}
