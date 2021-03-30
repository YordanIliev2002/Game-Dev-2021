using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector2 spawnPoint;
    public int yThreshhold = -10;
    private bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < yThreshhold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        isAlive = true;
        gameObject.transform.position = spawnPoint;
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        if(body)
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            body.velocity = Vector2.zero;
        }
    }

    public void Die()
    {
        isAlive = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Invoke("Respawn", 2f);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
