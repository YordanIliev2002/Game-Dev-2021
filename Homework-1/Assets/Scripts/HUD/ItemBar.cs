using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour
{
    private ItemIcon[] items;

    protected virtual void OnEnable()
    {
        items = GetComponentsInChildren<ItemIcon>();
    }

    protected void UpdateStates(int count)
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i].ChangeState(i < count);
        }
    }
}
