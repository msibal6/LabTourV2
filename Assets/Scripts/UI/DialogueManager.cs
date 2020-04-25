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

    public bool controlOverlayChecked;
    public bool anxiousOverlayChecked;
    public bool anxiousViewed;
    public bool controlViewed;

    private bool introduced;
    private bool slidesChecked;
    private bool micChecked;
    private bool pcChecked;
    private bool allViewed;
    private bool anxiousPicked;
    private bool controlPicked;
    private bool filterViewed;
    private bool noFilterViewed;
    private bool filterPicTaken;
    private bool noFilterPicTaken;

    private InteractionController tempPlayer;
    private DialogueBox displayedBox;
    private GameObject shownStart;
    private int maxHintNumber;
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
        SceneManager.sceneUnloaded += SceneClene;
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

        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name.ToString())
        {
            case "LabRoom":
                ShowLabRoomTips();
                break;
            case "NewMicroscopeView":
                ShowMicroscopeTips();
                break;

            default:
                break;
        }
    }

    private void ShowLabRoomTips()
    {
        if (tempPlayer == null) tempPlayer = FindObjectOfType<InteractionController>();


        if (instance.pcChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            tempPlayer.GetRaycastHit().collider.name == "Monitor")
        {
            instance.pcChecked = true;
        }

        if (instance.micChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            (tempPlayer.GetRaycastHit().collider.name == "Looking part" ||
            tempPlayer.GetRaycastHit().collider.name == "Looking part 1"))
        {
            instance.micChecked = true;
        }

        if (instance.slidesChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            tempPlayer.GetRaycastHit().collider.CompareTag("Slide"))
        {
            instance.slidesChecked = true;
        }

        if (instance.anxiousPicked == false && tempPlayer.GetHeldObject() != null
            && tempPlayer.GetHeldObject().name == "Anxious Mouse")
        {
            instance.anxiousPicked = true;
            Refresh(15);
        }

        if (instance.controlPicked == false && tempPlayer.GetHeldObject() != null
            && tempPlayer.GetHeldObject().name == "Control Mouse")
        {
            instance.controlPicked = true;
            Refresh(13);
        }

        if (instance.allViewed == false && instance.pcChecked == true
            && instance.micChecked == true && instance.slidesChecked == true)
        {
            instance.allViewed = true;
        }
    }

    private void ShowMicroscopeTips()
    {
        if (instance.anxiousViewed == false && MySceneManager.instance.slideDisplayed == "Anxious Mouse")
        {
            instance.anxiousViewed = true;
            Refresh(16);
        }

        if (instance.controlViewed == false && MySceneManager.instance.slideDisplayed == "Control Mouse")
        {
            instance.controlViewed = true;
            Refresh(14);
        }

        if (instance.noFilterViewed == false && MySceneManager.instance.slideDisplayed != "")
        {
            instance.noFilterViewed = true;
        }

        if (instance.filterViewed == false && MySceneManager.instance.slideDisplayed != "")
        {
            Toggle filter = FindObjectOfType<Toggle>();
            if (filter.isOn)
            {
                instance.filterViewed = true;
                Refresh(17);
            }
        }

        if (instance.noFilterPicTaken == false && MySceneManager.instance.slideDisplayed != "")
        {
            GameObject objectButton = GameObject.Find("Take Image");
            Button button = objectButton.GetComponentInChildren<Button>();
            Toggle filter = FindObjectOfType<Toggle>();
            button.onClick.AddListener(DisplayNoFilterTaken);
            void DisplayNoFilterTaken()
            {
                if (instance.noFilterPicTaken == false && !filter.isOn)
                {
                    instance.noFilterPicTaken = true;
                    print("no filter pic taken");
                    Refresh(19);
                }
            }
        }

        if (instance.filterPicTaken == false && MySceneManager.instance.slideDisplayed != "")
        {
            GameObject objectButton = GameObject.Find("Take Image");
            Button takeImage = objectButton.GetComponentInChildren<Button>(); Toggle filter = FindObjectOfType<Toggle>();
            takeImage.onClick.AddListener(DisplayFilterTaken);
            void DisplayFilterTaken()
            {
                if (filter.isOn && instance.filterPicTaken == false)
                {
                    instance.filterPicTaken = true;
                    Refresh(20);
                }
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

    public void Refresh(int index)
    {
        currentLine = index;
        ShowDialogue();
        displayedBox.text.text = dialogLines[currentLine];
    }
    private void SceneClene(Scene scene)
    {
        RemoveClones();
    }

    private void RemoveClones()
    {
        Destroy(displayedBox);
        Destroy(shownStart);
    }
}
