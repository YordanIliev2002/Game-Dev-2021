using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(shieldPrefab, collision.gameObject.transform);
            Destroy(gameObject);
        }
    }
}
