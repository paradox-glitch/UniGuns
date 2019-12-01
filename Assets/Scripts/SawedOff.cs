//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script controlls sawedoff weapon fire.

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Weapon))]

public class SawedOff : MonoBehaviour
{
    public string ammoType = "ammo9";
    public GameObject spawnedBullet01, bulletPrefab;
    public bool fireing, onlyOnce;
    public float fireRate = 0f, bulletSpeed = 6f, maxDistance = 6f, damage = 6f, singleShotDelay = 1.5f;

    void Update()
    {
        fireing = GetComponent<Weapon>().fireing;
        if (fireing == true && onlyOnce == false)
        {
            onlyOnce = true;
            StartCoroutine(FireRate());
        }
    }

    void Shoot()
    {
        if (GetComponent<Weapon>().player.GetComponent<PlayerController>().ammo9 > 0)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            float spred = -0.5f;
            for (int i = 0; i <= 6; i++)
            {
                spawnedBullet01 = Instantiate(bulletPrefab, this.gameObject.transform.GetChild(0).transform.position, transform.rotation) as GameObject;
                spawnedBullet01.transform.localScale = this.gameObject.transform.parent.localScale;
                spawnedBullet01.GetComponent<Bullet>().bulletAngle = spred;
                spawnedBullet01.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
                spawnedBullet01.GetComponent<Bullet>().maxDistance = maxDistance;
                spawnedBullet01.GetComponent<Bullet>().damage = damage;
                spred += 0.2f;
            }
            GetComponent<Weapon>().player.GetComponent<PlayerController>().ammo9--;
        }
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        Shoot();
        yield return new WaitForSeconds(singleShotDelay);
        onlyOnce = false;
    }
}