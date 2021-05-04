using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    int touchingObjectsCount = 0;

    public bool IsGrounded()
    {
        return touchingObjectsCount > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingObjectsCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingObjectsCount--;
    }

}
