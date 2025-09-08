using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Amulet : MonoBehaviour
{
    public void PickUp()
    {
        WorldManager.Instance.isAlreadyPickUp = true;
        Destroy(gameObject);
    }
}
