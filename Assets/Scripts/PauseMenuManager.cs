using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource audioSource;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        audioSource.Play();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        audioSource.Play();
    }
    public void ReturnToMM(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        audioSource.Play();
    }
}
