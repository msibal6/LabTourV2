using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
	public Text dText;
    public bool dialogActive;
	public string[] dialogLines; 
    public int currentLine;

	// Start a new queue of sentences to display
    void Start()
    {
        //sentences = new Queue<string>();
    }


    // Box and first message are displayed
    public void DisplayText(){
        if (dialogActive) {
            // dBox.SetActive(false);
            // dialogActive = false;

            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
        }

        dText.text = dialogLines[currentLine];
    }

    public void PrevText(){
        if (currentLine > 0){
            currentLine--;
        }
        
        dText.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialogue){
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue(){
        dialogActive = true;
        dBox.SetActive(true);
    }
}
