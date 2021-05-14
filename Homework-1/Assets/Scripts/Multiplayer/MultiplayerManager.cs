using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
using TMPro;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] private GameObject winnerScreen;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private List<Color> colors;

    private void Start()
    {
        switch(PlayerPrefs.GetString("role"))
        {
            case "host":
                NetworkManager.Singleton.StartHost();
                break;
            default:
                NetworkManager.Singleton.StartClient();
                break;
        }
    }

    public void Back()
    {
        Disconnect();
        Time.timeScale = 1;
        SceneManager.LoadScene("MultiplayerLobby");
    }

    public void Disconnect()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.StopHost();
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.StopClient();
        }
        else if (NetworkManager.Singleton.IsServer)
        {
            NetworkManager.Singleton.StopServer();
        }
    }

    public void DisplayWinner(string nickname)
    {
        winnerScreen.SetActive(true);
        winnerText.text = nickname + " won!";
        Time.timeScale = 0;
    }


    public Color GetUniqueColor()
    {
        if(colors == null || colors.Count == 0)
        {
            return Color.white;
        }
        int index = Random.Range(0, colors.Count);
        Color result = colors[index];
        colors.RemoveAt(index);
        return result;
    }
}
