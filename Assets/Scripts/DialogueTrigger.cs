using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
    public Sprite extraIcon;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool autoStart = false; 
    public bool requireInteraction = true;


    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && autoStart)
        { 
            TriggerDialogue();
        
        }
    }

}
