using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rigidBody;

    private WeaponSlot availableWeaponSlot;
    private bool isInteractingWithWeapon = false;

    void Awake()
    {
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WeaponSlot"))
        {
            availableWeaponSlot = collider.GetComponent<WeaponSlot>();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("WeaponSlot"))
        {
            availableWeaponSlot = null;
            isInteractingWithWeapon = false;
        }
    }

    void Update()
    {
        if (availableWeaponSlot && availableWeaponSlot.AvailableForInteraction && Input.GetButtonDown("Jump"))
        {
            isInteractingWithWeapon = !isInteractingWithWeapon;
            availableWeaponSlot.SetPlayerInteraction(isInteractingWithWeapon);
        }
        if (isInteractingWithWeapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                availableWeaponSlot.Fire();
            }
            availableWeaponSlot.AimAt(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    void FixedUpdate()
    {
        if (!isInteractingWithWeapon)
        {
            Vector2 movingTo = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rigidBody.velocity = movingTo * speed;
        }
    }
}
