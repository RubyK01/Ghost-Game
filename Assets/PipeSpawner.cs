using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnDelay = 1.5f; // Delay of when the next pair of pipes spawn
    public float spawnPosX = 10f; // spawn position of pipes
    public float minSpawnPosY = -1f; // minimum length of a pipe
    public float maxSpawnPosY = 3f; // maximun length of a pipe
    public float despawnPosX = -15f; // Position pipes are despawned off screen.
    public int maxPipesOnScreen = 20;  // Maximum number of pipes allowed on screen
    private int currentPipesOnScreen = 0;  // Current number of pipes on screen
    private bool pipesOnScreen = false;  // Boolean to track if there are currently any pipes on screen

    private void Start()
    {
        // Spawn the initial pair of pipes
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        if (!pipesOnScreen && currentPipesOnScreen < maxPipesOnScreen)
        {
            // Generate a random spawn position for the new pipes
            // float spawnPosY = Random.Range(minSpawnPosY, maxSpawnPosY);
            // Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            // Instantiate the new pipes
            GameObject newPipes = Instantiate(pipePrefab, transform.position, transform.rotation);

            // Increment the number of pipes on screen and set the boolean to true
            currentPipesOnScreen++;
            pipesOnScreen = true;
        }
    }

    private void Update()
    {
        // Check if any pipes have moved offscreen and despawn them
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            if (pipe.transform.position.x < despawnPosX)
            {
                Destroy(pipe);
                currentPipesOnScreen--;
                pipesOnScreen = false;
            }
        }
    }
}
