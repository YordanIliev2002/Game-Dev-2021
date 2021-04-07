using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBar : ItemBar
{
    protected override void Awake()
    {
        base.Awake();
        GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCollector>().onKeyCountChange += UpdateStates;
    }
}
