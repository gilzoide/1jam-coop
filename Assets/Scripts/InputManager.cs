using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{ 
  public void Baboseira(InputAction.CallbackContext ctx)
  {
    if (ctx.performed) {
      print(ctx.control.displayName);
      print(ctx.control.device);
    }
  }
}
