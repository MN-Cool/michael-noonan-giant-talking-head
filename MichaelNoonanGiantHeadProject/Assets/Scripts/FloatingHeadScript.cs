using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHeadScript : MonoBehaviour
{
    void Start()
    {
        
    }

    private void Update()
    {
        if (DialogueManager.isActive == true)
            return;
    }
}
