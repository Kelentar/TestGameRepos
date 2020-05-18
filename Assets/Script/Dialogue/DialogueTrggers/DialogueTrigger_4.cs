using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_4 : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public void OnTriggerStay2D(Collider2D NPC)
    {
        if (NPC.transform.CompareTag("NPC1") && Input.GetButton("Fire3"))
        {
            //Debug.Log("Dialog");
            dialogueManager.StartDialogue(NPC.GetComponent<Dialogue>());
            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        //if (NPC.transform.CompareTag("NPC"))
        //{
        //    //Debug.Log("Dialog");
        //    dialogueManager.StartDialogue(NPC.GetComponent<Dialogue>());
        //    //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //}
    }
}
