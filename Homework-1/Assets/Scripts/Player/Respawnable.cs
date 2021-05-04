using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawnable : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    private int health;
    public delegate void OnHealthChange(int health);
    public OnHealthChange onHealthChange;

    private bool isAlive = true;
    public delegate void OnIsAliveChange(bool isAlive);
    public OnIsAliveChange onIsAliveChange;

    private Vector2 spawnPoint;
    public int yThreshhold = -10;

    void Start()
    {
        spawnPoint = gameObject.transform.position;
        health = maxHealth;
        if(onHealthChange != null)
        {
            onHealthChange(health);
        }
    }

    void Update()
    {
        if(gameObject.transform.position.y < yThreshhold)
        {
            Hurt();
            Respawn();
        }
    }

    public void Respawn()
    {
        isAlive = true;
        if (onIsAliveChange != null)
        {
            onIsAliveChange(isAlive);
        }
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
        if (!isAlive) 
        {
            return;
        }
        Hurt();
        isAlive = false;
        if (onIsAliveChange != null)
        {
            onIsAliveChange(isAlive);
        }
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Invoke("Respawn", 2f);
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void Hurt()
    {
        health--;
        if (onHealthChange != null)
        {
            onHealthChange(health);
        }
    }
}
