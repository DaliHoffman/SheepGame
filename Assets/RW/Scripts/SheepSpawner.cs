// The SheepSpawner script is responsible for spawning sheep in the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns = 2f;
    public float spawnRateIncrease = 0.05f; // increase in spawn rate every 60 seconds
    public float timeToIncreaseSpawnRate = 30f; // time interval to increase spawn rate
    private List<GameObject> sheepList = new List<GameObject>();
    private int numSheepSpawned = 0;
    private float timeSinceLastSpawn = 0f;
    private float timeSinceLastSpawnRateIncrease = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Increase spawn rate every timeToIncreaseSpawnRate seconds
        timeSinceLastSpawnRateIncrease += Time.deltaTime;
        if (timeSinceLastSpawnRateIncrease >= timeToIncreaseSpawnRate)
        {
            timeBetweenSpawns -= spawnRateIncrease;
            timeSinceLastSpawnRateIncrease = 0f;
        }
    }
    // Spawn a sheep at the specified spawn point
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().runSpeed += numSheepSpawned * 0.1f;
        sheep.GetComponent<Sheep>().SetSpawner(this);
        numSheepSpawned++;
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            // Spawn a sheep if enough time has elapsed since the last spawn
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= timeBetweenSpawns)
            {
                SpawnSheep();
                timeSinceLastSpawn = 0f;
            }

            yield return null;
        }
    }
    // Remove a sheep from the sheep list
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


    // Removes all sheep from game
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }
        sheepList.Clear();
    }
}