using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHeadScript : MonoBehaviour
{
    public Animator headAnimator;

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
}
