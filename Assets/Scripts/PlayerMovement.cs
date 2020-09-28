using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rigidBody;
    public WeaponInfo personalWeaponInfo;
    public Crosshair crosshair;
    public RepeatedShooter repeatedShooter;

    private InteractableObject availableInteractableObject;
    private WeaponSlot availableWeaponSlot;
    private SpriteRenderer sprite;
    private Animator animator;
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
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (gameObject.scene.IsValid())
        {
            isShooting = ctx.performed;
        }
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
            else if (availableInteractableObject)
            {
                availableInteractableObject.Activate();
            }
        }
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        if (gameObject.scene.IsValid())
        {
            movePosition = ctx.ReadValue<Vector2>();
        }
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
        if (collider.CompareTag("WeaponSlot"))
        {
            availableWeaponSlot?.SetPlayerInteraction(false);
            availableWeaponSlot = null;
            isInteractingWithWeapon = false;
        }
        else if (collider.CompareTag("Interactable"))
        {
            availableInteractableObject = null;
        }
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
        if (!isInteractingWithWeapon)
        {
            if (movePosition.x != 0)
            {
                sprite.flipX = movePosition.x > 0;
            }
            animator.SetBool("walking", movePosition != Vector2.zero);
            rigidBody.velocity = movePosition * speed;
        }
    }
}
