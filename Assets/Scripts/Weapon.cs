using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool attacking;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float speed = 3f;
    public void Attack()
    {
        GameObject bullet=Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Move(firePoint.right);
    }
}
