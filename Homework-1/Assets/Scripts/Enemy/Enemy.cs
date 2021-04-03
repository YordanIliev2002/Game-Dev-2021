using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private SpriteRenderer spriteRender;
    private GroundChecker groundChecker;
    [SerializeField] float distanceThreshholdX = 6;
    [SerializeField] float distanceThreshholdY = 6;
    [SerializeField] float deathThreshholdY = -10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.position.y < deathThreshholdY)
        {
            Destroy(gameObject);
        }
        float distanceX = player.transform.position.x - transform.position.x;
        float distanceY = player.transform.position.y - transform.position.y;
        if(Mathf.Abs(distanceX) <= distanceThreshholdX)
        {
            spriteRender.flipX = Mathf.Sign(distanceX) == -1;
        }
        animator?.SetBool("isPlayerClose", Mathf.Abs(distanceX) <= distanceThreshholdX && Mathf.Abs(distanceY) <= distanceThreshholdY);
        animator?.SetBool("isGrounded", groundChecker.IsGrounded());
    }

}
