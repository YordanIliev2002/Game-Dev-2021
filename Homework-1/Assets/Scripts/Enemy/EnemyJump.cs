using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : StateMachineBehaviour
{
    public float jumpStrength = 5;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody2D body = animator.GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(body.velocity.x, jumpStrength);
    }
}
