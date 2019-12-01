//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Chooses the top 3 players.

using UnityEngine;
using UnityEngine.SceneManagement;

public class Podium : MonoBehaviour
{
    public int bronze = -1, silver = -1, gold = -1;
    public int bronzePlayer, silverPlayer, goldPlayer;
    public GameObject bronzePlace, silverPlace, goldPlace;
    public GameObject[] prefabPlayers = new GameObject[8];
    float coolDown = 5;
    int coolDownRound;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if (PlayerManager.joinPlayers[i])
            {
                if (PlayerManager.playerScore[i] > gold)
                {
                    gold = PlayerManager.playerScore[i];
                    goldPlayer = i;
                }
            }
            if (PlayerManager.joinPlayers[i] && i != goldPlayer)
            {
                if (PlayerManager.playerScore[i] > silver)
                {
                    silver = PlayerManager.playerScore[i];
                    silverPlayer = i;
                }
            }
            if (PlayerManager.activePlayers > 2)
            {
                if (PlayerManager.joinPlayers[i] && i != goldPlayer && i != silverPlayer)
                {
                    if (PlayerManager.playerScore[i] > bronze)
                    {
                        bronze = PlayerManager.playerScore[i];
                        bronzePlayer = i;
                    }
                }
            }
        }
        if (PlayerManager.activePlayers > 2)
            PlayerManager.spawnedPlayers[bronzePlayer] = Instantiate(prefabPlayers[bronzePlayer], bronzePlace.transform.position, transform.rotation) as GameObject;
        PlayerManager.spawnedPlayers[silverPlayer] = Instantiate(prefabPlayers[silverPlayer], silverPlace.transform.position, transform.rotation) as GameObject;
        PlayerManager.spawnedPlayers[goldPlayer] = Instantiate(prefabPlayers[goldPlayer], goldPlace.transform.position, transform.rotation) as GameObject;
    }

    void Update()
    {
        coolDown += -Time.deltaTime;
        coolDownRound = Mathf.RoundToInt(coolDown);
        GameObject.Find("Returning").GetComponent<TMPro.TextMeshProUGUI>().text = ("RETURNING TO MENU IN " + coolDownRound);
        if (coolDown <= 0)
        {
            PlayerManager.CleanUp();
            SceneManager.LoadScene("100-MainMenu");
        }
    }
}