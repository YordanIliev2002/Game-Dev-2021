using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        KeyCollector collector = collision.gameObject.GetComponent<KeyCollector>();
        if (collector != null)
        {
            collector.CollectKey();
            Destroy(gameObject);
        }
    }
}
