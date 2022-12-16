using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    public FloatingHead2Script floatingHead2;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform dialogueBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    [SerializeField] private AudioClip dialogueAudio;
    private AudioSource audioManager;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayDialogue();
        dialogueBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayDialogue()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        floatingHead2.HeadTalking();
        audioManager.PlayOneShot(dialogueAudio);

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayDialogue();
        }
        else
        {
            isActive = false;
            floatingHead2.HeadStopTalking();
            dialogueBox.transform.localScale = Vector3.zero;
            Debug.Log("This conversation is over!");
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    void Awake()
    {
        audioManager = this.gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        dialogueBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}
