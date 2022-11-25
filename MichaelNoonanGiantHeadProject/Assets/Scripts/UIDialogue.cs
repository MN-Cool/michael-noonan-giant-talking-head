using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UIDialogue : MonoBehaviour
{
    private Text dialogueText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingSound;

    private void Awake()
    {
        dialogueText = transform.Find("DialogueBox").Find("DialogueText").GetComponent<Text>();
        talkingSound = transform.Find("TalkingSound").GetComponent<AudioSource>();

        transform.Find("DialogueBox").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[]
                {
                    "Hello there!",
                    "",
                };

                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(dialogueText, message, 0.05f, true, true, StopTalkingSound);
            }
        };
    }

    private void StartTalkingSound()
    {
        talkingSound.Play();
    }

    private void StopTalkingSound()
    {
        talkingSound.Stop();
    }
}
