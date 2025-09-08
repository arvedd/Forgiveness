using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public NpcDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialougeText, nameText;
    public Image potraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    
}
