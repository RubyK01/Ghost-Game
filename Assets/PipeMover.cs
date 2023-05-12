using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeMover : MonoBehaviour
{
    public float speed = 5f;
    public float despawnX = -30f;
    
    private void Update()
    {
        // Move the pipes to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the pipes have gone off screen
        if (transform.position.x < despawnX)
        {
            // Destroy the pipes when they go off screen
            Destroy(gameObject);
        }
    }
}
