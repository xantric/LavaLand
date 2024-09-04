using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject InstructionsPanel;
    public AudioSource audioSource;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.Play();
    }
    public void Back(){
        InstructionsPanel.SetActive(false);
        audioSource.Play();

    }
    public void LoadInstructions()
    {
        InstructionsPanel.SetActive(true);
        audioSource.Play();
    }
    public void QuitGame()
    {
        Application.Quit();
        audioSource.Play();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        audioSource.Play();
    }

}
