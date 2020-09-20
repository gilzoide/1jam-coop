using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rigidBody;

    void Awake()
    {
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    void FixedUpdate()
    {
        Vector2 movingTo = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = movingTo * speed;
    }
}
