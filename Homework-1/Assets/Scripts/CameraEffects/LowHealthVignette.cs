using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHealthVignette : MonoBehaviour
{
    [SerializeField] Material material;
    private bool isActive = false;

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Respawnable>().onHealthChange += CheckPlayerHealth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(isActive)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void CheckPlayerHealth(int health)
    {
        isActive = health <= 1;
    }
}
