using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject resumeButton;

   public void PauseButtonClick()
    {
        Time.timeScale = 0;

        exitButton.SetActive(true);
        resumeButton.SetActive(true);

        pauseButton.SetActive(false);

    }
    public void ResumeButtonClick()
    {
        Time.timeScale = 1f;

        exitButton.SetActive(false);
        resumeButton.SetActive(false);


        pauseButton.SetActive(true);
    }
    public void ExitButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
