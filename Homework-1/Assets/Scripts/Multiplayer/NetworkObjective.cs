using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class NetworkObjective : NetworkBehaviour
{

    [ServerRpc(RequireOwnership = false)]
    private void AnnounceWinnerServerRpc(string name)
    {
        DisplayWinnerClientRpc(name);
    }

    [ClientRpc]
    private void DisplayWinnerClientRpc(string name)
    {
        GameObject.FindGameObjectWithTag("MultiplayerManager").GetComponent<MultiplayerManager>().DisplayWinner(name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AnnounceWinnerServerRpc(collision.gameObject.GetComponent<Player>().nickname.Value);
        }
    }
}
