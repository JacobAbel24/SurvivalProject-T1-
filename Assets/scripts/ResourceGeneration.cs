using UnityEngine;

public class ResourceGeneration : MonoBehaviour
{
    private int randomX;
    private int randomZ;
    public int numberOfItems = 60;
    public GameObject[] prefab;

    void Start()
    {
        if (prefab != null)
        {
            SpawnRandomPrefabs();
        }
        else
        {
            Debug.LogWarning("No items found!");
        }
    }

    void SpawnRandomPrefabs()
    {

            for (int i = 0; i < numberOfItems; i++)
            {
                randomX = Random.Range(-24, 24);
                randomZ = Random.Range(-24, 24);
                int randomIndex = Random.Range(0, prefab.Length);
                Vector3 randomPosition = new Vector3(randomX, 0.19f, randomZ);

                GameObject randomPrefab = prefab[randomIndex];
                Instantiate(randomPrefab, randomPosition, Quaternion.identity);
            }
    }
}
