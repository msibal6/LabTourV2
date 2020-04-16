using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    public Mutton backButton;
    public Mutton contButton;
    public Image background;
    public Text text;
    public DialogueManager dialogueManager;

    // Start is called before the first frame
    void Start()
    {
        Disable();
        text.text = dialogueManager.dialogLines[0];
    }

    public void Disable()
    {
        backButton.Disable();
        contButton.Disable();
        background.enabled = false;
        text.enabled = false;
    }

    public void Enable()
    {
        backButton.Enable();
        contButton.Enable();
        background.enabled = true;
        text.enabled = true;
    }
}
