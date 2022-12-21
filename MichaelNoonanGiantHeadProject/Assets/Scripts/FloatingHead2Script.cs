using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloatingHead2Script : MonoBehaviour
{
    public InputActionReference rightControllerInteractRef = null;
    public InputActionReference rightControllerInteractRef2 = null;
    public Animator headAnimator;
    public DialogueManager2 dialogueManager2;
    private DialogueTrigger2 dialogueTrigger2;

    public GameObject tutorialScreen;

    void Awake()
    {
        rightControllerInteractRef.action.performed += Select;
        rightControllerInteractRef2.action.performed += Activate;
    }

    void Start()
    {
        headAnimator = GetComponent<Animator>();
        dialogueTrigger2 = GetComponent<DialogueTrigger2>();
    }

    private void Update()
    {
        if (DialogueManager2.isActive == true)
            return;
    }

    public void HeadTalking()
    {
        headAnimator.SetLayerWeight(headAnimator.GetLayerIndex("Talking Layer"), 1f);
    }

    public void HeadStopTalking()
    {
        headAnimator.SetLayerWeight(headAnimator.GetLayerIndex("Talking Layer"), 0);
    }

    public void Select(InputAction.CallbackContext context)
    {
            tutorialScreen.SetActive(false);
            dialogueTrigger2.StartDialogue();
    }

    public void Activate(InputAction.CallbackContext context)
    {
            dialogueManager2.NextMessageActive();
    }
}
