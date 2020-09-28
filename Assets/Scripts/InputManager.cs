using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    PlayerControls control;
    List<string> connectedControls = new List<string>();

    void Awake()
    {
        control = new PlayerControls();
        control.Player.Shoot.performed += ctx => GetInput(ctx);
    }

    public void GetInput(InputAction.CallbackContext ctx)
    {
        if (connectedControls.Count >= 4) return;

        if (ctx.control.displayName == "V")
        {
            if (connectedControls.Find(e => e == "Keyboard Left") == null)
            {
                AddPlayer("Keyboard Left", "Keyboard Left", ctx.control.device);
            }
        }
        else if (ctx.control.displayName == ".")
        {
            if (connectedControls.Find(e => e == "Keyboard Right") == null)
            {
                AddPlayer("Keyboard Right", "Keyboard Right", ctx.control.device);
            }
        }
        else if (ctx.control.name == "buttonWest")
        {
            if (connectedControls.Find(e => e == ctx.control.device.ToString()) == null)
            {
                AddPlayer(ctx.control.device.ToString(), "Gamepad", ctx.control.device);
            }
        }
    }

    void AddPlayer(string deviceAlias, string controlScheme, InputDevice device)
    {
        connectedControls.Add(deviceAlias);
        PlayerInput.Instantiate(
            playerPrefabs[connectedControls.Count - 1],
            controlScheme: controlScheme,
            pairWithDevice: device
        );
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
