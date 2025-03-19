using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; 
    public float spawnInterval = 2.0f; 

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnFood();
            nextSpawnTime = Time.time + spawnInterval; 
        }
    }

    void SpawnFood()
    {
        if (foodPrefabs.Length == 0)
        {
            Debug.LogWarning("No food prefabs assigned to the spawner!");
            return;
        }

        // Pick a random food prefab
        int randomIndex = Random.Range(0, foodPrefabs.Length);

        // Instantiate the selected food prefab at the spawner's location and rotation
        Instantiate(foodPrefabs[randomIndex], transform.position, transform.rotation);
    }
}

