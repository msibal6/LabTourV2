using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public Animator animator;
	private Queue<string> sentences; 


	// Start a new queue of sentences to display
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Box and first message are displayed
    public void StartDialogue (Dialogue dialogue)
    {

    	animator.SetBool("isOpen", true);
    	nameText.text = dialogue.name;

    	sentences.Clear();

    	foreach (string sentence in dialogue.sentences)
    	{
    		sentences.Enqueue(sentence);
    	}

    	DisplayNextSentence();
    }

    // Continue to display messages until the end
    public void DisplayNextSentence()
    {
    	if (sentences.Count == 0)
    	{
    		EndDialogue();
    		return;
    	}
    	string sentence = sentences.Dequeue();
    	dialogueText.text = sentence;
    }

    // Stop displaying messages and box disappears
    void EndDialogue(){
    	animator.SetBool("isOpen", false);
    }

}
