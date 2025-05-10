using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 100f;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        //LA ANIMACION FUNCIONA PERO PUEDE MOVERSE EL PERSONAJE
        // animator.SetTrigger("Die");
    }
}
