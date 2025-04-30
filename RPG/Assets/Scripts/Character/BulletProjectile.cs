using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    [SerializeField] private Transform bulletImpactEffect;
    [SerializeField] private float offSetSpawnParticles = 0.5f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        float speed = 40f;

        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bulletImpactEffect, transform.position - transform.forward*offSetSpawnParticles, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
