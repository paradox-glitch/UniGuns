//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Spawns Weapons and gives them to the player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    bool WeaponSpawned = false;
    float SpawnCooldown = 0f;
    public GameObject[] Weapons;
    int Weapon;
    public GameObject SpawnedWeapon;
    public Transform hand;

    void Update()
    {
        if (WeaponSpawned == true)
        {
            SpawnedWeapon.transform.position = GameObject.Find(gameObject.name + "/SpawnHere").transform.position;
            SpawnedWeapon.transform.rotation = GameObject.Find(gameObject.name + "/SpawnHere").transform.rotation;
        }
        else if (WeaponSpawned == false && SpawnCooldown <= 0)
        {
            Weapon = Mathf.RoundToInt(Random.Range(0, Weapons.Length));
            SpawnedWeapon = Instantiate(Weapons[Weapon], GameObject.Find(gameObject.name + "/SpawnHere").transform.position, transform.rotation) as GameObject;
            WeaponSpawned = true;
        }
        else if (WeaponSpawned == false && SpawnCooldown > 0)
            SpawnCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.name != "DamageTrigger" && other.GetComponent<PlayerController>().Weapon == null && WeaponSpawned == true)
        {
            if (other.transform.localScale.x == -1)
                SpawnedWeapon.transform.localScale = new Vector3(-1, 1, 1);
            SpawnedWeapon.transform.parent = other.transform;
            other.GetComponent<PlayerController>().Weapon = SpawnedWeapon;
            other.GetComponent<PlayerController>().ammo9 += 60;
            SpawnedWeapon.GetComponent<Weapon>().player = other.gameObject;
            SpawnedWeapon = null;
            SpawnCooldown = 5;
            WeaponSpawned = false;
        }
        else if (other.tag == "Player" && other.name != "DamageTrigger" && other.GetComponent<PlayerController>().Weapon != null && WeaponSpawned == true)
        {
            other.GetComponent<PlayerController>().ammo9 += 60;
            Destroy(SpawnedWeapon);
            SpawnedWeapon = null;
            SpawnCooldown = 5;
            WeaponSpawned = false;
        }
    }
}