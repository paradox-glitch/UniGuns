//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Spawns players in level, and manages some level functions.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] prefabPlayers = new GameObject[8], prefabPos = new GameObject[8], prefabScore = new GameObject[8], prefabScorePos = new GameObject[8];
    bool roundOver = false;
    public GameObject thatsRound;
    int coolDownRound;
    float coolDown = 5;
    string winner = null;

    void Start()
    {
        int rnd = Mathf.RoundToInt(Random.Range(0, 8));
        int scorePlace = 0;
        for (int i = 0; i < 8; i++)
        {
            if (PlayerManager.joinPlayers[i])
            {
                int rndnew = i + rnd;
                if (rndnew >= 8)
                    rndnew += -8;
                PlayerManager.spawnedPlayers[i] = Instantiate(prefabPlayers[i], prefabPos[rndnew].transform.position, transform.rotation) as GameObject;
                PlayerManager.spawnedPlayers[i].GetComponent<PlayerController>().healthBar = Instantiate(prefabScore[i]) as GameObject;
                PlayerManager.spawnedPlayers[i].GetComponent<PlayerController>().healthBar.transform.SetParent(prefabScorePos[scorePlace].transform);
                PlayerManager.spawnedPlayers[i].GetComponent<PlayerController>().healthBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                scorePlace++;
            }
        }
    }

    void Update()
    {
        int playersLeft = 0;
        for (int i = 0; i <= 7; i++)
        {
            if (PlayerManager.spawnedPlayers[i] != null)
                playersLeft++;
        }
        if (playersLeft == 1 && roundOver == false)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (PlayerManager.spawnedPlayers[i] != null)
                {
                    PlayerManager.UpdateScore(i);
                    roundOver = true;
                    winner = PlayerManager.spawnedPlayers[i].GetComponent<PlayerController>().PlayerNumber;
                }
            }
        }
        if (winner != null)
        {
            if (PlayerManager.playerScore[int.Parse(winner) - 1] >= PlayerManager.scoreToWin)
            {
                PlayerManager.keepAudio = false;
                coolDown += -Time.deltaTime;
                coolDownRound = Mathf.RoundToInt(coolDown);
                thatsRound.GetComponent<TMPro.TextMeshProUGUI>().text = ("PLAYER " + winner + " TAKES THIER FINAL ROUND");
                if (coolDown <= 0)
                    SceneManager.LoadScene("102-Winner");
            }
            else
            {
                PlayerManager.keepAudio = true;
                coolDown += -Time.deltaTime;
                coolDownRound = Mathf.RoundToInt(coolDown);
                thatsRound.GetComponent<TMPro.TextMeshProUGUI>().text = ("PLAYER " + winner + " TAKES THIS ROUND \n NEXT IN " + coolDownRound);
                if (coolDown <= 0)
                    SceneLoader.RandomPlayScene();
            }
        }
    }
}