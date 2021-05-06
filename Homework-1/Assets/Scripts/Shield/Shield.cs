using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shield : MonoBehaviour
{
    private Animator animator;
    public float durationLeft = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        durationLeft -= Time.deltaTime;
        if(durationLeft < 0)
        {
            animator.SetTrigger("expire");
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
