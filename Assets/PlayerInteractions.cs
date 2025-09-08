using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.ShaderGraph.Serialization;
using Unity.VisualScripting;
using System.Collections;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI switchWorldText;
    [SerializeField]
    public TextMeshProUGUI interactText;
    [SerializeField]
    public GameObject emmaAlter;
    private Amulet amulet;
    private DialogueTrigger currentDialogue;
    private bool pickUpAllowed = false;
    public float delayTime = 0.1f;
    public float fadeDuration = 0.1f;

    void Awake()
    {
        // switchWorldText.gameObject.SetActive(false);
        interactText.gameObject.SetActive(false);
        emmaAlter.gameObject.SetActive(false);
    }

    void ActivateObject()
    {
        StartCoroutine(FadeInObject());
    }

    IEnumerator FadeInObject()
    {
        emmaAlter.SetActive(true);

        SpriteRenderer sr = emmaAlter.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogWarning("emmaAlter tidak punya SpriteRenderer!");
            yield break;
        }

        Color c = sr.color;
        c.a = 0f; // mulai transparan
        sr.color = c;

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration); // naik dari 0 → 1
            c.a = alpha;
            sr.color = c;
            yield return null;
        }

        // pastikan alpha full
        c.a = 1f;
        sr.color = c;
    }

    public void TriggerEmmaAlter()
    {
        Invoke("ActivateObject", delayTime);
    }

    public void OnPickUpAmulet(InputAction.CallbackContext context)
    {
        if (context.performed && pickUpAllowed && amulet != null)
        {
            amulet.PickUp();
            Debug.Log("Tombol E ditekan");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
    {
        Debug.Log("Tombol Interact ditekan!");
        

            if (currentDialogue != null && currentDialogue.requireInteraction)
            {
                Debug.Log("Triggering Dialogue: " + currentDialogue.name);
                currentDialogue.TriggerDialogue();

            }
            else
            {
                Debug.Log("Tidak ada currentDialogue atau requireInteraction = false");
            }
    }

    }


    public void SetCurrentDialogue(DialogueTrigger dialogue)
    {
        currentDialogue = dialogue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HotDogNPC"))
        {
            TriggerEmmaAlter();
            currentDialogue = collision.GetComponent<DialogueTrigger>();

            if (currentDialogue != null && currentDialogue.requireInteraction)
            {
                interactText.gameObject.SetActive(true);
                Debug.Log("collision dengan: " + currentDialogue.name);
            }
        }



        // if (collision.gameObject.CompareTag("SwitchPoint"))
        // {
        //     switchWorldText.gameObject.SetActive(true);
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HotDogNPC"))
        {
            interactText.gameObject.SetActive(false);
            currentDialogue = null;
        }

        if (collision.gameObject.CompareTag("SwitchPoint"))
        {
            switchWorldText.gameObject.SetActive(false);
        }
    }

}
