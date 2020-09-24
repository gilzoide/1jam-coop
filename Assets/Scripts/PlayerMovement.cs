using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rigidBody;
    public WeaponInfo personalWeaponInfo;
    public Crosshair crosshair;
    public RepeatedShooter repeatedShooter;

    private WeaponSlot availableWeaponSlot;
    private Vector2 movePosition;
    private bool isInteractingWithWeapon = false;
    private bool isShooting;
    private bool isInteracting;
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

    public void Shoot(InputAction.CallbackContext ctx)
    {
        isShooting = ctx.performed;
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        isInteracting = ctx.performed;
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        movePosition = ctx.performed ? ctx.ReadValue<Vector2>() : Vector2.zero;
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
        if (availableWeaponSlot && availableWeaponSlot.AvailableForInteraction && isInteracting)
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
            availableWeaponSlot.RotateCrosshair(movePosition.x);
        }
        else if (isShooting)
        {
            crosshair.AimDirectional(movePosition.x, movePosition.y);
            repeatedShooter.Shoot(personalWeaponInfo);
        }
    }

    void FixedUpdate()
    {
        if (!isInteractingWithWeapon)
        {
            rigidBody.velocity = movePosition * speed;
        }
    }
}
