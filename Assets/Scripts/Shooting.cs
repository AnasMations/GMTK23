using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPos;
    public GameObject Bullet;
    public float ShootForce;
    public float ShootDelay;
    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= shotTime)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                shotTime = Time.time + ShootDelay;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, shootingPos.position, shootingPos.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(shootingPos.up * ShootForce, ForceMode2D.Impulse);
    }
}
