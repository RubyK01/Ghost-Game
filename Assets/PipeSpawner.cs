using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // The prefab for the pipe
    public float pipeSpeed = 3f; // The speed at which the pipes move towards the player
    public float pipeScaleMin = 0.5f; // The minimum scale for the pipes
    public float pipeScaleMax = 2f; // The maximum scale for the pipes
    public float colliderOffset = 0.5f; // The offset for the pipe's box collider
    public float spawnRate = 2;
    private float spawnTimer = 0; // The timer for spawning pipes
    public float speed = 2.0f;
    public float despawnX = -10f;

    void Start()
    {
        // Move the pipe to the left of the screen if it is already on screen
        if (transform.position.x > -3.5f)
        {
            transform.position = new Vector3(-6.0f, transform.position.y, transform.position.z);
        }
    }
    
    void Update()
    {

         // Move the pipe to the left
        transform.position +=  (Vector3.left * speed) * Time.deltaTime;

        spawnTimer += Time.deltaTime;

        // If the spawn timer has reached the spawn delay, spawn a pipe and reset the timer
        if (spawnTimer < spawnRate)
        {
            SpawnPipe();
            spawnTimer += Time.deltaTime;
            spawnTimer = 0;
        }

        if (transform.position.x < despawnX)
        {
            // Destroy the pipes when they go off screen
            Destroy(gameObject);
        }
    }

    void SpawnPipe()
    {
        Instantiate (pipePrefab, transform.position, transform.rotation);
        // Instantiate a new pipe from the pipe prefab
        // GameObject newPipe = Instantiate(pipePrefab, transform.position, transform.rotation);

        // // Set the scale of the new pipe to a random value between pipeScaleMin and pipeScaleMax
        // float pipeScale = Random.Range(pipeScaleMin, pipeScaleMax);
        // newPipe.transform.localScale = new Vector3(pipeScale, pipeScale, 1f);

        // Set the position of the new pipe to be off-screen to the right
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0.2f, 0.8f), 10f));
        pipePrefab.transform.position = spawnPos;

        // // Set the velocity of the new pipe to move towards the player
        // Rigidbody2D rb = newPipe.GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(-pipeSpeed, 0f);

        // // Adjust the box collider for the new pipe based on its scale
        // BoxCollider2D collider = newPipe.GetComponent<BoxCollider2D>();
        // collider.size = new Vector2(collider.size.x, pipeScale - colliderOffset);
        // collider.offset = new Vector2(collider.offset.x, -colliderOffset / 2f);
    }
}
