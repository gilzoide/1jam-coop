using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public GameObject playerPrefab;

    PlayerControls control;
    List<string> connectedControls = new List<string>();

    void Awake()
    {
        control = new PlayerControls();
        control.Player.Shoot.performed += ctx => GetInput(ctx);
    }

    public void GetInput(InputAction.CallbackContext ctx)
    {
        if (connectedControls.Count == 4) return;

        if (ctx.control.displayName == "V")
        {
            if (connectedControls.Find(e => e == "Keyboard Left") == null)
            {
                connectedControls.Add("Keyboard Left");
                PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard Left", pairWithDevice : ctx.control.device);
            }
        }
        else if (ctx.control.displayName == ".")
        {
            if (connectedControls.Find(e => e == "Keyboard Right") == null)
            {
                connectedControls.Add("Keyboard Right");
                PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard Right", pairWithDevice : ctx.control.device);
            }
        }
        else if (ctx.control.name == "buttonWest")
        {
            if (connectedControls.Find(e => e == ctx.control.device.ToString()) == null)
            {
                connectedControls.Add(ctx.control.device.ToString());
                PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice : ctx.control.device);
            }
        }
    }

    void OnEnable()
    {
        control.Enable();
    }

    void OnDisable()
    {
        control.Disable();
    }
}
