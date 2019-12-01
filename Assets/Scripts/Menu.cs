//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Controlls the main menu buttons and functions;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Update()
    {
        if (Input.anyKeyDown == true && Input.GetMouseButtonDown(0) == false && !settingsMenu.activeInHierarchy)
        {
            SceneManager.LoadScene("101-JoinMenu");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadOptions()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }
}