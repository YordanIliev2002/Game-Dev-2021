using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPlayer : StateMachineBehaviour
{
    public GameObject player;
    public float speed = 2;
    public float jumpThreshhold = 0.5f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody2D body = animator.GetComponent<Rigidbody2D>();
        float distanceToPlayer = player.transform.position.x - body.transform.position.x;
        if(Mathf.Abs(distanceToPlayer) < jumpThreshhold)
        {
            if(animator.GetBool("isGrounded"))
            {
                animator.SetTrigger("shouldJump");
            }
        }
        else
        {
            body.velocity = new Vector2(Mathf.Sign(distanceToPlayer) * speed, body.velocity.y);
        }
    }

}
