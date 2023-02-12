using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject DeathSound;

    void Awake()
    {
        Pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if(GamePaused == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
        Invoke("DieCheck", 0.5f);
    }

    
    public void PauseGame()
    {
        Pause.SetActive(true);
         Time.timeScale = 0f;
        GamePaused = true;

    }
    public void ResumeGame()
    {
         Time.timeScale = 1f;
        Pause.SetActive(false);
        GamePaused = false;
    }
    public void Restart()
    {
        GamePaused = false;
         Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
         Time.timeScale = 1f;
        Application.Quit();
    }
    void DieCheck()
    {
        if (Health.CurrentHealth == 0)
        {
            Restart();
            Health.CurrentHealth = 5;
        }
    }

}
