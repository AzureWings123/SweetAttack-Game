using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0 == 0) // collision.gameObject.CompareTag("DTrigger") == true
        {
            trigger.StartDialogue();
        }
        
    }
}
