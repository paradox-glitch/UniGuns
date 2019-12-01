//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Controlls functions of options menu.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void SetMaxScore(string score)
    {
        int intScore = int.Parse(score);
        if (intScore > 0 && intScore < 12)
            PlayerManager.scoreToWin = int.Parse(score);
    }
}