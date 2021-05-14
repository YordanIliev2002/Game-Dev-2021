using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
[RequireComponent(typeof(LevelGenerator))]
public class MultiplayerGenerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        yield return null; // Skip a frame so that host gets initialized;

        if (NetworkManager.Singleton.IsHost)
        {
            GetComponent<LevelGenerator>().GenerateLevel();
            DeepNetworkify(transform);
        }
    }

    private void DeepNetworkify(Transform go)
    {
        NetworkObject no = go.GetComponent<NetworkObject>();
        if (no && !no.IsSpawned)
        {
            no.Spawn();
        }

        for (int i = 0; i < go.transform.childCount; i++)
        {
            Transform child = go.transform.GetChild(i);
            DeepNetworkify(child);
        }
    }
}
