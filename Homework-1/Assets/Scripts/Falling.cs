using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Rigidbody2D body;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, 1f);
        }
    }

}
