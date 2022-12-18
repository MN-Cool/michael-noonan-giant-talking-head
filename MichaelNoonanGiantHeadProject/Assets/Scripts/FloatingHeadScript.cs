using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloatingHeadScript : MonoBehaviour
{
    public InputActionReference leftControllerInteractRef = null;
    public Animator headAnimator;
    public DialogueManager dialogueManger;

    void Awake()
    {
        leftControllerInteractRef.action.started += Activate;
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

    private void OnDestroy()
    {
        leftControllerInteractRef.action.started -= Activate;
    }

    private void Activate(InputAction.CallbackContext ctx)
    {

    }
}
