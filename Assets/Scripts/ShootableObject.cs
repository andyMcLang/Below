using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour, IDamageable
{
    public int currentHealth = 3;
    public GameObject hitParticles;

    private MeshRenderer myRenderer;

    void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }
    public void Damage(int damageAmount, Vector3 hitPoint, Vector3 hitNormal)
    {
        Instantiate(hitParticles, hitPoint, Quaternion.LookRotation(hitNormal));

        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            myRenderer.material.color = Color.green;
            // breaking
        }
    }
}
