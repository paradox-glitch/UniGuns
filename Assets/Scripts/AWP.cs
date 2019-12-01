//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script controlls awp weapon fire.

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Weapon))]

public class AWP : MonoBehaviour
{
    public GameObject spawnedBullet, bulletPrefab;
    public bool onlyOnce;
    public float fireRate = 0f, bulletSpeed = 8f, maxDistance = 100f, damage = 40f, singleShotDelay = 1.5f;

    void Update()
    {
        if (GetComponent<Weapon>().fireing == true && onlyOnce == false)
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
            spawnedBullet = Instantiate(bulletPrefab, this.gameObject.transform.GetChild(0).transform.position, transform.rotation) as GameObject;
            spawnedBullet.transform.localScale = this.gameObject.transform.parent.localScale;
            spawnedBullet.GetComponent<Bullet>().bulletAngle = 0;
            spawnedBullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
            spawnedBullet.GetComponent<Bullet>().maxDistance = maxDistance;
            spawnedBullet.GetComponent<Bullet>().damage = damage;
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
