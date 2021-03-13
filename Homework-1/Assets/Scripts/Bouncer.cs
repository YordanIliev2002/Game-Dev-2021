using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounciness = 1.5f;
    public float velocityLimit = 11f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Rigidbody2D body = other.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(body.velocity.x, Mathf.Min(velocityLimit, Mathf.Abs(bounciness * body.velocity.y)));
        }
    }
}
