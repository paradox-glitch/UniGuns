//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script controlls factors of the fired bullets.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    public float bulletAngle, bulletSpeed, maxDistance, damage;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.localScale.x == -1)
            GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed, bulletAngle, 0);
        if (transform.localScale.x == 1)
            GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, bulletAngle, 0);
        if (Vector2.Distance(startPos, transform.position) > maxDistance)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().health -= damage;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}