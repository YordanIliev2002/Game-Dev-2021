using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    private int keyCount = 0;
    private int maxCount = 3;

    public delegate void OnKeyCountChange(int count);
    public OnKeyCountChange onKeyCountChange;

    public void CollectKey()
    {
        if(keyCount < maxCount)
        {
            keyCount++;
            if (onKeyCountChange != null) {
                onKeyCountChange(keyCount); 
            }
        }
    }

    public bool TryConsumeKey()
    {
        if(keyCount > 0)
        {
            keyCount--;
            if (onKeyCountChange != null)
            {
                onKeyCountChange(keyCount);
            }
            return true;
        }
        return false;
    }
}
