using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    //public GameObject dBox;
    //public Text dText;
    public static DialogueManager instance;
    public DialogueBox dBox;
    public GameObject startButton;
    public bool dialogShowing;
    [TextArea(3, 10)]
    public string[] dialogLines;
    public int currentLine;

    private DialogueBox displayedBox;
    private GameObject shownStart;
    private int maxTipNumber;
    public Canvas canvas;

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
        SceneManager.sceneUnloaded += RemoveClones;
    }

    private void Update()
    {
        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
            UpdateClones();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowDialogue();
            print("h");
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

    

    private void UpdateClones()
    {
        displayedBox = Instantiate(instance.dBox);
        displayedBox.transform.position = instance.dBox.transform.position;
        displayedBox.transform.rotation = instance.dBox.transform.rotation;
        displayedBox.transform.SetParent(canvas.transform, true);
        shownStart = Instantiate(instance.startButton);
        shownStart.transform.position = instance.startButton.transform.position;
        shownStart.transform.SetParent(canvas.transform, true);

        if (dialogShowing)
        {
            displayedBox.Enable();
        }
        else
        {
            displayedBox.Disable();
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
            displayedBox.Disable();
            dialogShowing = false;
            currentLine--;
        }
        displayedBox.text.text = dialogLines[currentLine];
    }

    public void PrevText()
    {
        if (currentLine > 0)
        {
            currentLine--;
        }
        displayedBox.text.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogShowing = true;
        displayedBox.Enable();
        displayedBox.text.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogShowing = true;
        displayedBox.Enable();
    }

    private void RemoveClones(Scene scene)
    {
        Destroy(displayedBox);
        Destroy(shownStart);
    }


}
