using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHealthVignette : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] ConsumableBar healthBar;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(healthBar.GetCount() <= 1)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
