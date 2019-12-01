//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Controls Players; Portal, Jump, Move, Health, Fire, Drop, Weapon Movment.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //* Generic Info
    public string PlayerNumber;

    //* Jump
    public bool isGrounded;
    public int jumpCount = 0;

    //* Guns
    public GameObject Weapon;
    public int ammo9 = 100;

    //* Health
    public float health = 100;
    public GameObject healthBar;

    //* Portal
    public float portalCooldown = 0;

    void Update()
    {
        if (PlayerManager.gameIsPaused == false)
        {
            //* Portal
            if (portalCooldown > 0)
            {
                portalCooldown -= Time.deltaTime;
            }
            else if (portalCooldown < 0)
            {
                portalCooldown = 0;
            }

            //* Health
            if (healthBar != null)
            {
                healthBar.GetComponent<Image>().fillAmount = health / 100;
                healthBar.transform.GetChild(0).GetComponent<Text>().text = PlayerManager.playerScore[int.Parse(PlayerNumber) - 1].ToString();
            }
            if (health <= 0)
                Destroy(gameObject);

            //* Fire
            if (Input.GetButtonDown("P" + PlayerNumber + "-Fire") && Weapon != null)
                Weapon.GetComponent<Weapon>().fireing = true;
            if (Input.GetButtonUp("P" + PlayerNumber + "-Fire") && Weapon != null)
                Weapon.GetComponent<Weapon>().fireing = false;

            //* Drop
            if (Input.GetButtonDown("P" + PlayerNumber + "-Drop"))
            {
                Destroy(Weapon);
                Weapon = null;
            }

            //* Jump
            if (Input.GetButtonDown("P" + PlayerNumber + "-Jump") && jumpCount < 2)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, 5.0f, 0.0f) * 1f, ForceMode2D.Impulse);
                isGrounded = false;
                jumpCount++;
            }

            //* Flip
            if (Input.GetAxis("P" + PlayerNumber + "-Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetAxis("P" + PlayerNumber + "-Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //* Movement
            if (Input.GetAxis("P" + PlayerNumber + "-Horizontal") > 0.3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("P" + PlayerNumber + "-Horizontal") * 4, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (Input.GetAxis("P" + PlayerNumber + "-Horizontal") < -0.3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("P" + PlayerNumber + "-Horizontal") * 4, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (Input.GetAxis("P" + PlayerNumber + "-Horizontal") > -0.3 && Input.GetAxis("P" + PlayerNumber + "-Horizontal") < 0.3)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 0.9f, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    //* Weapon Movment
    private void LateUpdate()
    {
        if (Weapon != null)
        {
            Weapon.transform.position = GameObject.Find(gameObject.name + "/HoldHere").transform.position;
            Weapon.transform.rotation = GameObject.Find(gameObject.name + "/HoldHere").transform.rotation;
        }
    }
}