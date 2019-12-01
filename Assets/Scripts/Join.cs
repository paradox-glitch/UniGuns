//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script checks for input from players and markes them as joined.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Join : MonoBehaviour
{
    int minPlayers;
    int coolDownRound;
    float coolDown = 5;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PlayerManager.CleanUp();
            SceneManager.LoadScene("100-MainMenu");
        }

        for (int i = 1; i <= 8; i++)
        {

            if (Input.GetButtonDown("P0" + i + "-Join") && !PlayerManager.joinPlayers[i - 1])
            {
                PlayerManager.AddPlayer(i);
                minPlayers++;
                coolDown = 5;
            }
            if (PlayerManager.joinPlayers[i - 1])
            {
                GameObject.Find("Player0" + i + "/Unicorn").GetComponent<Image>().color = Color.Lerp(GameObject.Find("Player0" + i + "/Unicorn").GetComponent<Image>().color, Color.white, Time.deltaTime * 2);
                GameObject.Find("Player0" + i + "/Controls").GetComponent<Image>().color = Color.Lerp(GameObject.Find("Player0" + i + "/Controls").GetComponent<Image>().color, new Color(255, 0, 255, 1), Time.deltaTime * 2);
                GameObject.Find("Player0" + i + "/Join").GetComponent<Image>().color = Color.Lerp(GameObject.Find("Player0" + i + "/Join").GetComponent<Image>().color, new Color(255, 0, 255, 0.45f), Time.deltaTime * 2);
            }
        }

        if (minPlayers >= 2)
        {
            coolDown += -Time.deltaTime;
            coolDownRound = Mathf.RoundToInt(coolDown);
            GameObject.Find("Countdown").GetComponent<TMPro.TextMeshProUGUI>().text = ("STARTING IN " + coolDownRound);
            if (coolDown <= 0)
                PlayerManager.activePlayers = minPlayers;
                SceneLoader.RandomPlayScene();
        }
    }
}