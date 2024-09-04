using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject InstructionsPanel;
    public GameObject MMPanel;
    public AudioSource audioSource;
    public AudioSource BGambience;
    public FadeInOut fade;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.Play();
    }
    public void Back(){
        InstructionsPanel.SetActive(false);
        MMPanel.SetActive(true);
        audioSource.Play();

    }
    public void LoadInstructions()
    {
        InstructionsPanel.SetActive(true);
        MMPanel.SetActive(false);
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
    private void Start()
    {
        BGambience.Play();
    }
}
