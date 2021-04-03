using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtDistortionEffect : MonoBehaviour
{
    [SerializeField] Material material;
    private bool isEnabled = false;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isEnabled)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void setState(bool shouldEnable)
    {
        isEnabled = shouldEnable;
    }
}
