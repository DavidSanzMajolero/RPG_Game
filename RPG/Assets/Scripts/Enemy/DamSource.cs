using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamSource : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController healthController = other.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(20f); 
            }
        }

    }
    
}
