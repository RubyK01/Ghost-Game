using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghosty : MonoBehaviour{
    public float jumpForce = 10f;
    public float rotateSpeed = 200f;
    public float rotateAngle1 = 80f;
    public float rotateAngle2 = -35f;

    private Rigidbody2D rb;
    private bool isDead;
    public string currentScene;
    private float currentRotation;
    private float targetRotation;
    private float rotationDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        currentRotation = transform.rotation.eulerAngles.z;
        targetRotation = rotateAngle1;
        rotationDirection = 1f;
         currentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rb.velocity = Vector2.up * jumpForce;
            rotationDirection *= -1f;

            if (rotationDirection > 0f)
            {
                targetRotation = rotateAngle1;
            }
            else
            {
                targetRotation = rotateAngle2;
            }
        }

        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(currentScene);
        }

        currentRotation += rotationDirection * rotateSpeed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, rotateAngle2, rotateAngle1);
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
    }
}