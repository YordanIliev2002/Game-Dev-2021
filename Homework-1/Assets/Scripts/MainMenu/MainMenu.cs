using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 160;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayProcedural()
    {
        SceneManager.LoadScene("ProceduralLevel");
    }

    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerLobby");
    }
}
