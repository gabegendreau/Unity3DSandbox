using UnityEngine;

public class SpawnLog : MonoBehaviour
{
    Transform[] spawnLocations;
    public GameObject angryLogPrefab;
    bool playerInArena;
    public float minRespawnTime;
    public float maxRespawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = GetComponentsInChildren<Transform>();
        playerInArena = false;
    }

    void SpawnNewLog()
    {
        int randInt = Random.Range(0, 11);
        float randTime = Random.Range(minRespawnTime, maxRespawnTime);
        Instantiate(angryLogPrefab, spawnLocations[randInt].position, Quaternion.identity);
        if (playerInArena)
        {
            Invoke("SpawnNewLog", randTime);
        }
    }

    public void SetPlayerInArena(bool value)
    {
        if (value)
        {
            playerInArena = true;
            SpawnNewLog();
        } else {
            playerInArena = false;
        }
    }
}
