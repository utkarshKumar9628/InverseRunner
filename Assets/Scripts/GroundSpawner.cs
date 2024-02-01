using System.Collections;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs; // Array of different ground prefabs
    public int numberOfTilesToSpawn = 5; // Number of tiles to spawn in a row
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 6f;
    public float minheight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            float randomSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(randomSpawnRate);
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < numberOfTilesToSpawn; i++)
        {
            int randomPrefabIndex = Random.Range(0, groundPrefabs.Length);
            GameObject ground = Instantiate(groundPrefabs[randomPrefabIndex], transform.position, Quaternion.identity);
            ground.transform.position = new Vector3(
                ground.transform.position.x + i,
                Random.Range(minheight, maxHeight),
                0
            );
        }
    }
}