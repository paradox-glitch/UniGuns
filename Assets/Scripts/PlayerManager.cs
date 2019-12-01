//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Stores important information for the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool[] joinPlayers = new bool[8], deadPlayers = new bool[8];
    public static GameObject[] spawnedPlayers = new GameObject[8];
    public static int[] playerScore = new int[8];
    public static int scoreToWin = 2;
    public static bool gameIsPaused = false;
    public static bool keepAudio = false;
    public static int activePlayers;

    public static void AddPlayer(int playerNumber)
    {
        joinPlayers[playerNumber - 1] = true;
    }

    public static void UpdateScore(int playerNumber)
    {
        playerScore[playerNumber]++;
    }

    public static void CleanUp()
    {
        joinPlayers = new bool[8];
        deadPlayers = new bool[8];
        spawnedPlayers = new GameObject[8];
        playerScore = new int[8];
    }
}