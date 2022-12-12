using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogues dibox;
    public GameObject canvas;
    
    private void Start() {
        canvas.GetComponent<DialogueManager>().StartDialogue(dibox);
        // Debug.Log(canvas.GetComponent<DialogueManager>());
    }

  
}
