using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject[] asteroidPrefabs;
    public float spawnRate = 2.0f;
    public float spawnWidth = 10.0f;

    private float nextSpawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void Spawn()
    {

        int asteroidIndex = Random.Range(0,asteroidPrefabs.Length); // Getting the asteroid size on the prefabs list

        float randomY = Random.Range(-spawnWidth / 2, spawnWidth / 2);
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + randomY);

        Instantiate(asteroidPrefabs[asteroidIndex], spawnPosition, Quaternion.identity);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 size = new Vector3(0.5f, spawnWidth, 1);
        Gizmos.DrawWireCube(transform.position, size);
    }

}
