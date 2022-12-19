using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloatingHeadScript : MonoBehaviour
{
    public InputActionReference leftControllerInteractRef = null;
    public InputActionReference leftControllerInteractRef2 = null;
    public Animator headAnimator;
    public DialogueManager dialogueManager;
    private DialogueTrigger dialogueTrigger;

    void Awake()
    {
        leftControllerInteractRef.action.started += Select;
        leftControllerInteractRef2.action.started += Activate;
    }

    void Start()
    {
        headAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (DialogueManager.isActive == true)
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
        dialogueTrigger.StartDialogue();
    }

    public void Activate(InputAction.CallbackContext ctx)
    {
        dialogueManager.NextMessageActive();
    }
}
