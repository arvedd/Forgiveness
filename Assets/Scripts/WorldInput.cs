using UnityEngine;
using UnityEngine.InputSystem;

public class WorldInput : MonoBehaviour
{
    public void OnSwitchWorld(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            WorldManager.Instance.SwitchWorld();
            Debug.Log("Sudah tekan Q");
        }
    }
}
