using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject pauseWindow;

    void Start()
    {
        pauseWindow.SetActive(false);
    }
    public void Pause()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
        
    }
    public void ExitPause()
    {
        Time.timeScale = 1;
        int curr = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curr - 1);
    }
    public void Play()
    {
        int curr = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curr + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
