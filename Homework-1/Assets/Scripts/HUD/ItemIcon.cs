using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite full;
    [SerializeField] private Sprite empty;
    [SerializeField] private bool isFull = false;
    [SerializeField] private Animator animator;
    public void Start()
    {
        ChangeState(isFull);
    }
    public void ChangeState(bool state)
    {
        isFull = state;
        image.sprite = state ? full : empty;
        if(animator)
        {
            animator.SetBool("isFull", isFull);
        }
    }
}
