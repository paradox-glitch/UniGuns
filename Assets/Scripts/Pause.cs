//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Controls pause menu and its functions.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel, settingsPanel;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale != 0f)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
            PlayerManager.gameIsPaused = !PlayerManager.gameIsPaused;
        }
    }

    public void Resume()
    {
        if (Time.timeScale != 0f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        pausePanel.SetActive(!pausePanel.activeInHierarchy);
        PlayerManager.gameIsPaused = !PlayerManager.gameIsPaused;
    }

    public void Exit()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            PlayerManager.gameIsPaused = false;
        }
        PlayerManager.keepAudio = false;
        PlayerManager.CleanUp();
        SceneManager.LoadScene("100-MainMenu");
    }

    public void LoadOptions()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }
}