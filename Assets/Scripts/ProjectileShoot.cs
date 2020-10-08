using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform gunEnd;
    public float force = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, gunEnd.position, Quaternion.identity);

            clone.velocity = gunEnd.TransformDirection(Vector3.forward * force);
        }
    }
}
