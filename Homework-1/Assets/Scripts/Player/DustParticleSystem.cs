using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    public void Play()
    {
        if (system)
        {
            system.Play();
        }
    }

    public void Stop()
    {
        if(system)
        {
            system.Stop();
        }
    }

    public void Burst()
    {
        system.Emit(15);
    }
}
