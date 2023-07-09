using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public float yConstraint;
    public float damage;
    public int Health = 3;

    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x, yConstraint, transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        SleepMeter.SleepoMeter -= damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health -= 1;
            transform.localScale /= 1.15f;
            if (Health < 0)
            {
                die();
            }
        }
    }

    void die()
    {
        SleepMeter.SleepoMeter += 5f;
        Destroy(gameObject);
    }
}