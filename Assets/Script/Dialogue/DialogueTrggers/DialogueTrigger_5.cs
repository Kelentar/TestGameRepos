using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_5 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Animator anim;
    public void OnTriggerStay2D(Collider2D NPC)
    {
        if (NPC.transform.CompareTag("NPC5") && Input.GetButton("Fire3"))
        {
            Debug.Log("Dialog");
            dialogueManager.StartDialogue(NPC.GetComponent<Dialogue>());
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("NPC5"))
        {
            Debug.Log("Dialog");
            anim.SetBool("EOpen", true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("NPC5"))
        {

            anim.SetBool("EOpen", false);
            dialogueManager.EndDialogue();
        }
    }
}
