using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnKeyAtRandomLocation();
    }

    void SpawnKeyAtRandomLocation()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(keyPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
    }
}
