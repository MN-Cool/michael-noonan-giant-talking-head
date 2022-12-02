using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Head") == true)
            trigger.StartDialogue();
    }
}
