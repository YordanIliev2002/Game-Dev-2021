using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPill : MonoBehaviour
{
    private GameObject affectedPlayer;
    [SerializeField]
    private float duration = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            affectedPlayer = collision.gameObject;
            Take();
            gameObject.SetActive(false);
            Invoke("Take", duration);
            Destroy(gameObject, duration + 1);
        }
    }

    void Take()
    {
        Rigidbody2D body = affectedPlayer.GetComponent<Rigidbody2D>();
        body.gravityScale = -body.gravityScale;
    }

}
