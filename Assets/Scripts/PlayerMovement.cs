using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rigidBody;
    public WeaponInfo personalWeaponInfo;
    public Crosshair crosshair;
    public RepeatedShooter repeatedShooter;

    private WeaponSlot availableWeaponSlot;
    private bool isInteractingWithWeapon = false;
    private bool isShooting;
    private float horizontalAxis;
    private float verticalAxis;

    void Awake()
    {
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        if (!crosshair)
        {
            crosshair = GetComponentInChildren<Crosshair>();
        }
        if (!repeatedShooter)
        {
            repeatedShooter = GetComponentInChildren<RepeatedShooter>();
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
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        isShooting = Input.GetButton("Fire1");
        if (availableWeaponSlot && availableWeaponSlot.AvailableForInteraction && Input.GetButtonDown("Jump"))
        {
            isInteractingWithWeapon = !isInteractingWithWeapon;
            availableWeaponSlot.SetPlayerInteraction(isInteractingWithWeapon);
        }
        if (isInteractingWithWeapon)
        {
            if (isShooting)
            {
                availableWeaponSlot.Fire();
            }
            availableWeaponSlot.RotateCrosshair(horizontalAxis);
        }
        else if (isShooting)
        {
            crosshair.AimDirectional(horizontalAxis, verticalAxis);
            repeatedShooter.Shoot(personalWeaponInfo);
        }
    }

    void FixedUpdate()
    {
        if (!isInteractingWithWeapon)
        {
            Vector2 movingTo = new Vector2(horizontalAxis, verticalAxis);
            rigidBody.velocity = movingTo * speed;
        }
    }
}
