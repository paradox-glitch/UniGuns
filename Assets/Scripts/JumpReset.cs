//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script resets player jump when they hit the ground.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReset : MonoBehaviour
{
    private void OnCollisionEnter2D()
    {
        this.transform.parent.GetComponent<PlayerController>().jumpCount = 0;
    }
}