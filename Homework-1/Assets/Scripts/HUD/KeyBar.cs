using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBar : ItemBar
{
    protected override void OnEnable()
    {
        base.OnEnable();
        GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCollector>().onKeyCountChange += UpdateStates;
    }
}
