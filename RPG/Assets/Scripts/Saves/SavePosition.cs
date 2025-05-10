using UnityEngine;

public class SavePosition : MonoBehaviour
{
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Vector3 position = other.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", position.x);
            PlayerPrefs.SetFloat("PlayerPosY", position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", position.z);
            PlayerPrefs.Save();
        }
    }
}