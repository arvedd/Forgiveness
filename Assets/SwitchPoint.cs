using System;
using UnityEngine;

public class SwitchPoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WorldManager.Instance.canSwitchWorld = true;
            Debug.Log("Bisa pindah");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            WorldManager.Instance.canSwitchWorld = false;
        }
    }
}
