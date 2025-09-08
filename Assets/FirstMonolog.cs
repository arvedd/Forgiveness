using UnityEngine;

public class FirstMonolog : MonoBehaviour
{
    private DialogueTrigger dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogue.TriggerDialogue();
        }
    }
}
