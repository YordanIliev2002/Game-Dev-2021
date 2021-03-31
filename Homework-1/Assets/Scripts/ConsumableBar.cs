using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableBar : MonoBehaviour
{
    [SerializeField] private int startingCount = 0;
    private int availableCount = 0;
    private Consumable[] consumables;
    private void Start()
    {
        consumables = GetComponentsInChildren<Consumable>();
        availableCount = startingCount;
        UpdateStates();
    }

    void UpdateStates()
    {
        for(int i = 0; i < consumables.Length; i++)
        {
            consumables[i].ChangeState(i < availableCount);
        }
    }

    public void ConsumeOne()
    {
        if (availableCount > 0)
        {
            availableCount--;
            UpdateStates();
        }
    }

    public void CollectOne() 
    {
        if(availableCount < consumables.Length)
        {
            availableCount++;
            UpdateStates();
        }
    }

    public void Reset()
    {
        availableCount = startingCount;
    }

    public int GetCount()
    {
        return availableCount; 
    }
}
