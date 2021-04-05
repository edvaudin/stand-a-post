using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] float fireRate = 0.2f;
    private float fireTimer = Mathf.Infinity;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (fireTimer > fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }

        fireTimer += Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
