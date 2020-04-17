using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    //public GameObject dBox;
    //public Text dText;
    public DialogueManager instance;
    public DialogueBox dBox;
    public bool dialogShowing;
    [TextArea(3, 10)]
    public string[] dialogLines;
    public int currentLine;

    private int maxTipNumber;
    private Canvas canvas;

    // Start a new queue of sentences to display
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        dialogShowing = true;
        canvas = FindObjectOfType<Canvas>();
        //gameObject.transform.parent = canvas.transform;

        //SceneManager.sceneUnloaded += RemoveParent;

    }

    void RemoveParent(Scene scene)
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            dBox.Enable();
            transform.parent = null;

        }

        if (dialogShowing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayText();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                PrevText();
            }
        }
    }

    // Box and first message are displayed
    public void DisplayText()
    {
        if (dialogShowing)
        {

            currentLine++;

        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.Disable();
            dialogShowing = false;
            currentLine--;
            transform.parent = null;

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
