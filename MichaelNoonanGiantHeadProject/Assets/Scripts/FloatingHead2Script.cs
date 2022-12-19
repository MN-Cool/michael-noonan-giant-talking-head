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

    void Awake()
    {
        rightControllerInteractRef.action.started += Select;
        rightControllerInteractRef2.action.started += Activate;
    }

    void Start()
    {
        headAnimator = GetComponent<Animator>();
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

    public void Select(InputAction.CallbackContext ctx)
    {
        dialogueTrigger2.StartDialogue();
    }

    public void Activate(InputAction.CallbackContext ctx)
    {
        dialogueManager2.NextMessageActive();
    }
}
