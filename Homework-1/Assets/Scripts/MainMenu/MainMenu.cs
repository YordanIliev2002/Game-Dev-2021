using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
