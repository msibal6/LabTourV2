using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //public GameObject dBox;
    //public Text dText;
    public DialogueBox dBox;
    public bool dialogShowing;
    [TextArea(3, 10)]
    public string[] dialogLines;
    public int currentLine;
    private int maxTipNumber;

    // Start a new queue of sentences to display
    void Start()
    {
        //sentences = new Queue<string>();
    }


    // Box and first message are displayed
    public void DisplayText()
    {
        if (dialogShowing)
        {

            currentLine++;
            print(currentLine);

        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.Disable();
            dialogShowing = false;
            currentLine--;
            print(currentLine);


        }

        dBox.text.text = dialogLines[currentLine];
    }

    public void PrevText()
    {

        if (currentLine > 0)
        {
            currentLine--;
        }
        dBox.text.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogShowing = true;
        dBox.Enable();
        dBox.text.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogShowing = true;
        //dBox.SetActive(true);
        dBox.Enable();
    }
}
