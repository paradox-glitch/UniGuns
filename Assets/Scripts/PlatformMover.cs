//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Moves a platform between to predefined points.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float movementSpeed = 0.1f, errorSpace = 0.01f;
    public GameObject platform, target01, target02, currentTarget;

    void Start()
    {
        platform = GameObject.Find("/" + gameObject.name + "/Main");
        target01 = GameObject.Find("/" + gameObject.name + "/EndPoint01");
        target02 = GameObject.Find("/" + gameObject.name + "/EndPoint02");
        currentTarget = target01;
    }

    void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, currentTarget.transform.position, movementSpeed * Time.deltaTime);
        if (platform.transform.position.x >= target01.transform.position.x - errorSpace && platform.transform.position.x <= target01.transform.position.x + errorSpace && platform.transform.position.y >= target01.transform.position.y - errorSpace && platform.transform.position.y <= target01.transform.position.y + errorSpace)
            currentTarget = target02;
        else if (platform.transform.position.x >= target02.transform.position.x - errorSpace && platform.transform.position.x <= target02.transform.position.x + errorSpace && platform.transform.position.y >= target02.transform.position.y - errorSpace && platform.transform.position.y <= target02.transform.position.y + errorSpace)
            currentTarget = target01;
    }
}