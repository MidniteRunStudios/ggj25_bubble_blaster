using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs; // Array to hold the 3 prefabs
    public int numberOfObjects = 100; // Number of objects to instantiate
    public float spawnRadius = 10f; // Radius around the spawner within which to spawn objects
    public float minY = -10f; // Minimum height for Y position
    public float minScale = 1f; // Minimum scale factor
    public float maxScale = 10f; // Maximum scale factor
    void Start()
    {
        // Check if prefabs array is not empty
        if (prefabs.Length == 0)
        {
            Debug.LogError("No prefabs assigned to the spawner!");
            return;
        }

        // Instantiate objects at random positions within the spawn radius
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Randomly select a prefab from the array
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Generate a random position within the spawn radius
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Randomize the Y position within the specified range
            randomPosition.y = Random.Range(minY, spawnRadius);

            // Instantiate the prefab at the random position
            var spawnedObject = Instantiate(prefab, randomPosition, Quaternion.identity);

            // Apply random scaling to the instantiated object
            float randomScale = Random.Range(minScale, maxScale);
            spawnedObject.transform.localScale = Vector3.one * randomScale;
        }
    }
}
