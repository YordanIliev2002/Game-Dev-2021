using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector2 spawnPoint;
    public int yThreshhold = -10;
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
        gameObject.transform.position = spawnPoint;
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        if(body)
        {
            body.velocity = Vector2.zero;
        }
    }
}
