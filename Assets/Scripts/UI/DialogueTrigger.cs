using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
	public string dialogue;
	private DialogueManager dMan;
	[TextArea(3, 10)]
	public string[] dialogueLines;

	void Start(){
		dMan = FindObjectOfType<DialogueManager>();
	}

	// trigger dialogue to appear 
	public void TriggerDialogue ()
	{
        if (!dMan.dialogShowing)
        {
            dMan.ShowDialogue();
        }
    }

    public void TriggerSpecificDialogue(int index)
    {
		dMan.currentLine = index;
	}
}
