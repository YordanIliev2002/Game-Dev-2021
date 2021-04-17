using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverHUD;
    [SerializeField] GameObject LevelCompletedHUD;
    [SerializeField] GameObject NextLevelButtonHUD;
    private static string LEVEL_PREFIX = "Level";

    private void Start()
    {
        Application.targetFrameRate = 160;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Respawnable>().onHealthChange += checkPlayerHealth;
    }

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
    public void DisplayLevelCompleted()
    {
        Time.timeScale = 0;
        LevelCompletedHUD.SetActive(true);
        NextLevelButtonHUD.SetActive(HasNextLevel());
    }

    public void NextLevel()
    {
        int levelID = Int32.Parse(SceneManager.GetActiveScene().name.Substring(LEVEL_PREFIX.Length));
        levelID++;
        SceneManager.LoadScene(LEVEL_PREFIX + levelID);
        Time.timeScale = 1;
    }

    public bool HasNextLevel()
    {
        int levelID = Int32.Parse(SceneManager.GetActiveScene().name.Substring(LEVEL_PREFIX.Length));
        levelID++;
        return Application.CanStreamedLevelBeLoaded(LEVEL_PREFIX + levelID);
    }

    public void checkPlayerHealth(int health)
    {
        if(health < 1)
        {
            DisplayGameOver();
        }
    }
}
