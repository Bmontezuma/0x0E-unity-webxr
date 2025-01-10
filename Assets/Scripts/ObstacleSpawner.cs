using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnArea;
    public int maxObstacles = 10;

    private void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < maxObstacles; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-spawnArea.localScale.x / 2, spawnArea.localScale.x / 2),
                0,
                Random.Range(0, spawnArea.localScale.z)
            );
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
