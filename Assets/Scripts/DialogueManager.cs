using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();
    public TextMeshProUGUI dialogueText;

    private void Start() {
        //sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogues dialogue){
        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char l in sentence.ToCharArray()){
            dialogueText.text += l;
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void EndDialogue(){
        this.gameObject.SetActive(false);
    }
}
