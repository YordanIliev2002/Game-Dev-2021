using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    [SerializeField] private ConsumableBar keyBar;

    public void CollectKey()
    {
        keyBar.CollectOne();
    }

    public bool TryConsumeKey()
    {
        if(keyBar.GetCount() > 0)
        {
            keyBar.ConsumeOne();
            return true;
        }
        return false;
    }
}
