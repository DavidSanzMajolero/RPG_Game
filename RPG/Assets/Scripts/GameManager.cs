using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject CoversInterior;
    [SerializeField] private GameObject CoversExterior;
    [SerializeField] private GameObject PBRExterior;
    [SerializeField] private Transform spawnPoint;

    private bool firstTime = true;

    public Transform player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {

        CoversInterior.SetActive(true);
        CoversExterior.SetActive(false);
        if (Input.GetKeyDown(KeyCode.G))
        {
        }
    }

    public void SpawnNewEnemy()
    {
        if (firstTime)
        {
            StartCoroutine(SpawnAfterDelay());
            firstTime = false;
        }
    }

    private IEnumerator SpawnAfterDelay()
    {
        Destroy(CoversInterior);
        CoversExterior.SetActive(true);

        yield return new WaitForSeconds(5f); 

        if (PBRExterior != null && spawnPoint != null)
        {
            Instantiate(PBRExterior, spawnPoint.position, Quaternion.identity);
        }
    }

}
