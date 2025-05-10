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
        Destroy(gameObject);
        if (openDoorObj == null)
        {
            Debug.Log("OpenDoor is already open.");
            return;
        }
        else
        {
            GameManager.Instance.SpawnNewEnemy();
            openDoorObj.OpenDoorEvent();
        }
    }
}
