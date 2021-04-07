using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : ItemBar
{
    protected override void Awake()
    {
        base.Awake();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Respawnable>().onHealthChange += UpdateStates;
    }
}
