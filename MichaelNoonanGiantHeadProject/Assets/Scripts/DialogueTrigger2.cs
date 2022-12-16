using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger2 : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager2>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message2
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor2
{
    public string name;
    public Sprite sprite;
}
