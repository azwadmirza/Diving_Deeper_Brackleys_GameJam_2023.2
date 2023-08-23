using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float xBound;
    public float yBound1;
    public float yBound2;
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    private Quaternion initialRotation;
    private Vector2 movement;
    private float rotationAngle = 45f;
    private Quaternion targetRotation = Quaternion.identity;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //movement direction vector
        movement = new Vector2(horizontal, vertical);

        //checking movement direction
        if (horizontal > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, rotationAngle);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            targetRotation = Quaternion.Euler(0, 0, -rotationAngle);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (horizontal == 0f)
        {
            targetRotation = initialRotation;
        }

        //checking bounds and keeping the player inside bound
        if(transform.position.x >= xBound)
            transform.position = new Vector3(xBound, transform.position.y, 0);
        if (transform.position.x <= -xBound)
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        if (transform.position.y >= yBound1)
            transform.position = new Vector3(transform.position.x, yBound1, 0);
        if (transform.position.y <= yBound2)
            transform.position = new Vector3(transform.position.x, yBound2, 0);
    }

    private void FixedUpdate()
    {
        //check for movement direction and move the player
        if (movement != null)
        {
            rb.velocity = movement.normalized * speed;
        }

        //rotate the player
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        rb.MoveRotation(rotation);

    }
}
