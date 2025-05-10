using UnityEngine;

public class LoadPosition : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            CharacterController player = GetComponent<CharacterController>();
            if (player != null) player.enabled = false;

            transform.position = new Vector3(x, y, z);

            if (player != null) player.enabled = true;
        }
    }
}