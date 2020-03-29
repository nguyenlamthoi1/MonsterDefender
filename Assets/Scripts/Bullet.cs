using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;
    public Rigidbody2D rb;
    public Monster monster;
    public void Move(Vector2 dir)
    {
        rb.velocity = dir * -bulletSpeed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
             monster= other.GetComponent<Monster>();
            if (monster != null) { monster.TakeDamage(damage);}
            Destroy(gameObject);
        }
    }
}
