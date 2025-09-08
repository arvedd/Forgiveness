using UnityEngine;

[CreateAssetMenu(fileName = "NewNpcDialogue", menuName = "NPC Dialogue")]
public class NpcDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcFace;
    public string[] dialogueLine;
    public bool[] autoProgressLine;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
    

}
