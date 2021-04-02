using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverHUD;

    public void DisplayGameOver()
    {
        Time.timeScale = 0;
        gameOverHUD.SetActive(true);
    }

    public void Restart()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
        Time.timeScale = 1;
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
