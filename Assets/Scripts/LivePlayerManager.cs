//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Used for debugging, makes the values from the PlayerManager viewable on an emptey object in game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayerManager : MonoBehaviour
{
    public bool[] joinPlayers = new bool[8], deadPlayers = new bool[8];
    public GameObject[] spawnedPlayers = new GameObject[8];
    public int[] playerScore = new int[8];

    void Update()
    {
        joinPlayers = PlayerManager.joinPlayers;
        deadPlayers = PlayerManager.deadPlayers;
        spawnedPlayers = PlayerManager.spawnedPlayers;
        playerScore = PlayerManager.playerScore;
    }
}