using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FinalTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera finalCamera;
    public static FinalTrigger Instance { get; private set; }
    public bool playerEntered = false;

    private void Awake()
    {
        finalCamera.gameObject.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Barrel.Instance.taked)
            {
                playerEntered = true;
                finalCamera.gameObject.SetActive(true);
            }
        }
    }
}
