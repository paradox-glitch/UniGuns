//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Teleports the player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.name != "DamageTrigger")
        {
            if (other.gameObject.GetComponent<PlayerController>().portalCooldown == 0)
            {
                other.GetComponent<PlayerController>().portalCooldown = 1f;
                other.transform.position = otherPortal.transform.position;
            }
        }
    }
}