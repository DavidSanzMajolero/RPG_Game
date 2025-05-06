using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  
    public OpenDoor openDoorObj; 

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
        openDoorObj.OpenDoorEvent();
        GameManager.Instance.SpawnNewEnemy();
        Destroy(gameObject);
    }
}
