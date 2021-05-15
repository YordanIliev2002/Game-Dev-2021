using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using TMPro;

public class ReadyChecker : NetworkBehaviour
{
    private NetworkVariableInt allCount = new NetworkVariableInt(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone, ReadPermission = NetworkVariablePermission.Everyone });
    private NetworkVariableInt readyCount = new NetworkVariableInt(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone, ReadPermission = NetworkVariablePermission.Everyone });
    [SerializeField] private GameObject starterPlatform;
    [SerializeField] private TMP_Text readyDividedByAll;
    [SerializeField] private GameObject readyUI;
    
    private void OnEnable()
    {
        allCount.OnValueChanged += UpdateCount;
        readyCount.OnValueChanged += UpdateCount;
    }

    private void OnDisable()
    {
        allCount.OnValueChanged -= UpdateCount;
        readyCount.OnValueChanged -= UpdateCount;
    }

    private void UpdateCount(int prev, int curr)
    {
        if(allCount.Value == readyCount.Value)
        {
            readyUI.SetActive(false);
        }
        starterPlatform.SetActive(allCount.Value == readyCount.Value);
        readyDividedByAll.text = readyCount.Value.ToString() + "/" + allCount.Value.ToString();
    }

    public void Ready()
    {
        readyCount.Value++;
    }

    public void Join()
    {
        allCount.Value++;
    }
}
