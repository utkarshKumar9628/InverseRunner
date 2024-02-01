using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; // The point where bullets will be spawned
    public GameObject bulletPrefab; // The bullet prefab
    public float bulletForce = 10f; // The force applied to the bullet

    void Update()
    {
        // Check if the player presses the fire button (e.g., left mouse button or space key)
        if (Input.GetButtonDown("Fire1")) // Adjust "Fire1" based on your input settings
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the Rigidbody2D of the bullet and apply force to it
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        // Destroy the bullet after 2 seconds
        StartCoroutine(DestroyBulletAfterDelay(bullet, 2f));
    }

    // Coroutine to destroy the bullet after a delay
    IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the bullet
        Destroy(bullet);
    }
}