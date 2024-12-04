using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject[] bullets;

    public int spawnCount = 10;

    public Transform bottomLeftCorner;
    public Transform topRightCorner;
    public float timeBetween = 5;
    private float currentTime = 0;

    void Start()
    {
        SpawnObjectsInRect();
    }

    void SpawnObjectsInRect()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        float randomX = Random.Range(bottomLeftCorner.position.x, topRightCorner.position.x);
        float randomY = Random.Range(bottomLeftCorner.position.y, topRightCorner.position.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        Instantiate(bullets[Random.Range(0, bullets.Length)], spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        if (Time.time > currentTime)
        {
            currentTime = Time.time + timeBetween;
            SpawnRandom();
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 bottomLeft = new Vector3(bottomLeftCorner.position.x, bottomLeftCorner.position.y, 0f);
        Vector3 bottomRight = new Vector3(topRightCorner.position.x, bottomLeftCorner.position.y, 0f);
        Vector3 topLeft = new Vector3(bottomLeftCorner.position.x, topRightCorner.position.y, 0f);
        Vector3 topRight = new Vector3(topRightCorner.position.x, topRightCorner.position.y, 0f);

        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, bottomLeft);
    }
}
