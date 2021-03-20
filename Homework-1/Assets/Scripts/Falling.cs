using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Vector2 startPosition;
    public Rigidbody2D body;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            Invoke("Kill", 1);
            Invoke("Respawn", 3);
        }
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = startPosition;
        body.bodyType = RigidbodyType2D.Kinematic;
    }

}
