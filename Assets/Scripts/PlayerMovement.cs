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
    private InteractableObject availableInteractableObject;
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
        // gameObject.scene.IsValid check is necessary due to a bug in InputSystem: http://answers.unity.com/answers/1762099/view.html
        if (ctx.performed && gameObject.scene.IsValid())
        {
            if (availableWeaponSlot && availableWeaponSlot.AvailableForInteraction)
            {
                isInteractingWithWeapon = !isInteractingWithWeapon;
                availableWeaponSlot.SetPlayerInteraction(isInteractingWithWeapon);
            }
            if (availableInteractableObject)
            {
                availableInteractableObject.Activate();
            }
        }
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        movePosition = ctx.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("WeaponSlot"))
        {
            availableWeaponSlot = collider.GetComponent<WeaponSlot>();
        }
        else if (collider.CompareTag("Interactable"))
        {
            availableInteractableObject = collider.GetComponent<InteractableObject>();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        availableWeaponSlot = null;
        isInteractingWithWeapon = false;
        availableInteractableObject = null;
    }

    void Update()
    {
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
        rigidBody.velocity = isInteractingWithWeapon ? Vector2.zero : movePosition * speed;
    }
}
