using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
	public string dialogue;
	private DialogueManager dMAn;
	[TextArea(3, 10)]
	public string[] dialogueLines;

	void Start(){
		dMAn = FindObjectOfType<DialogueManager>();
	}

	// trigger dialogue to appear 
	public void TriggerDialogue ()
	{
        if (!dMAn.dialogShowing)
        {
            dMAn.ShowDialogue();
        }
    }
}
