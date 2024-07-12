using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireSpeed = 20f;
    public float bulletLifetime = 3f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity directly
        bulletRb.velocity = firePoint.up * fireSpeed;

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifetime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Destroy the bullet
        Destroy(bullet);
    }
}