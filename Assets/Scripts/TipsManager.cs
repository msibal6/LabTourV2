using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipsManager : MonoBehaviour
{
    public static TipsManager instance;

    public bool controlOverlayChecked;
    public bool anxiousOverlayChecked;
    public bool anxiousViewed;
    public bool controlViewed;
    public PopUp[] tips;


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

    private Coroutine runningDisplay;

    private Canvas tipsArea;
    private PopUp currentPopUp;
    private InteractionController tempPlayer;

    // Start is called before the first frame update
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

        if (instance.introduced == false)
        {
            instance.runningDisplay = StartCoroutine(DisplayTips(0, 3, 0.5f));
            instance.introduced = true;
        }

        SceneManager.sceneUnloaded += SceneChangeCoroutine;
    }

    // Update is called once per frame
    void Update()
    {
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

    private void ShowMicroscopeTips()
    {
        if (instance.anxiousViewed == false && MySceneManager.instance.slideDisplayed == "Anxious Mouse")
        {
            //CloseRunningDisplay();
            instance.anxiousViewed = true;
            instance.runningDisplay = StartCoroutine(DisplayTip(15, 2.5f));
        }

        if (instance.controlViewed == false && MySceneManager.instance.slideDisplayed == "Control Mouse")
        {
            //CloseRunningDisplay();
            instance.controlViewed = true;
            instance.runningDisplay = StartCoroutine(DisplayTip(16, 2.5f));
        }

        if (instance.noFilterViewed == false && MySceneManager.instance.slideDisplayed != "")
        {
            instance.noFilterViewed = true;
            instance.runningDisplay = StartCoroutine(DisplayTip(17, 2.5f, true));
        }

        if (instance.filterViewed == false && MySceneManager.instance.slideDisplayed != "")
        {
            Toggle filter = FindObjectOfType<Toggle>();
            if (filter.isOn)
            {
                instance.filterViewed = true;
                instance.runningDisplay = StartCoroutine(DisplayTip(18, 2.5f, true));
            }
        }

        if (instance.noFilterPicTaken == false && MySceneManager.instance.slideDisplayed != "")
        {
            Button button = FindObjectOfType<Button>();
            Toggle filter = FindObjectOfType<Toggle>();
            button.onClick.AddListener(DisplayNoFilterTaken);

            void DisplayNoFilterTaken()
            {
                if (instance.noFilterPicTaken == false && !filter.isOn)
                {
                    instance.noFilterPicTaken = true;
                    instance.runningDisplay = StartCoroutine(DisplayTip(19, 2.5f, true));
                }
            }
        }

        if (instance.filterPicTaken == false && MySceneManager.instance.slideDisplayed != "")
        {
            Button takeImage = FindObjectOfType<Button>();
            Toggle filter = FindObjectOfType<Toggle>();
            takeImage.onClick.AddListener(DisplayFilterTaken);

            void DisplayFilterTaken()
            {
                if (filter.isOn && instance.filterPicTaken == false)
                {
                    instance.filterPicTaken = true;
                    instance.runningDisplay = StartCoroutine(DisplayTip(20, 2.5f, true));
                }

            }
        }
    }

    private void ShowLabRoomTips()
    {
        if (tempPlayer == null) tempPlayer = FindObjectOfType<InteractionController>();

        // Show computer tips
        if (instance.pcChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            tempPlayer.GetRaycastHit().collider.name == "Monitor")
        {
            // Handle interrupt another tip 
            //CloseRunningDisplay();
            instance.pcChecked = true;
            instance.runningDisplay = StartCoroutine(DisplayTips(4, 5, 0.5f));
        }

        // show microscope tips
        if (instance.micChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            (tempPlayer.GetRaycastHit().collider.name == "Looking part" ||
            tempPlayer.GetRaycastHit().collider.name == "Looking part 1"))
        {
            //CloseRunningDisplay();
            instance.micChecked = true;
            instance.runningDisplay = StartCoroutine(DisplayTips(6, 8, 0.5f));
        }

        // show general slide tips
        if (instance.slidesChecked == false && tempPlayer.GetRaycastHit().collider != null &&
            tempPlayer.GetRaycastHit().collider.CompareTag("Slide"))
        {
            //CloseRunningDisplay();
            instance.slidesChecked = true;
            instance.runningDisplay = StartCoroutine(DisplayTips(9, 10, 0.5f));
        }

        // Show slide pickup tips
        if (instance.anxiousPicked == false && tempPlayer.GetHeldObject() != null
            && tempPlayer.GetHeldObject().name == "Anxious Mouse")
        {
            //CloseRunningDisplay();
            instance.anxiousPicked = true;
            instance.runningDisplay = StartCoroutine(DisplayTip(11, 2f));
        }

        if (instance.controlPicked == false && tempPlayer.GetHeldObject() != null
            && tempPlayer.GetHeldObject().name == "Control Mouse")
        {
            //CloseRunningDisplay();
            instance.controlPicked = true;
            instance.runningDisplay = StartCoroutine(DisplayTip(12, 2f));
        }

        // Tip after you have looked at everything
        if (instance.allViewed == false && instance.pcChecked == true
            && instance.micChecked == true && instance.slidesChecked == true)
        {
            //CloseRunningDisplay();
            instance.allViewed = true;
            instance.runningDisplay = StartCoroutine(DisplayTips(13, 14, 0.5f, true));
        }
    }

    public IEnumerator DisplayTip(int index, float waitTime, bool waiting = false)
    {

        if (waiting)
        {
            while (instance.runningDisplay != null) yield return new WaitForSeconds(0.1f);
        }
        else
        {
            DisablePreviousTip();
        }

        instance.tipsArea = GetComponentInChildren<Canvas>();
        PopUp tip = instance.tips[index];
        //DisablePreviousTips();
        //tip.gameObject.SetActive(true);

        // Showing tip
        tip.transform.parent = instance.tipsArea.transform;
        tip.Display();
        instance.currentPopUp = tip;

        yield return new WaitForSeconds(waitTime);

        // Closing tip 
        tip.Close();
        tip.transform.parent = gameObject.transform;

        instance.currentPopUp = null;
        instance.runningDisplay = null;
    }

    // HACK FUTURE
    // Display tip group which checks if its a tip group 
    public IEnumerator DisplayTips(int start, int end, float betweenTime, bool waiting = false)
    {

        // When we want to display tip after one that is currently shown
        if (waiting)
        {
            while (instance.runningDisplay != null) yield return new WaitForSeconds(0.1f);
        }
        else
        {
            DisablePreviousTip();
        }

        instance.tipsArea = GetComponentInChildren<Canvas>();

        //DisablePreviousTips();

        for (int i = start; i <= end; i++)
        {

            // Calculations for how long to display text 
            PopUp tip = instance.tips[i];
            int characters = tip.text.text.Length;
            float words = characters / 5; // Average number of characters in word
            float waitTime = words / 300 * 60; // Average reading speed, seconds in minute

            // Activation
            //tip.gameObject.SetActive(true);
            tip.transform.parent = instance.tipsArea.transform;
            instance.currentPopUp = tip;
            tip.Display();
            yield return new WaitForSeconds(waitTime);

            // De-activation
            tip.Close();
            tip.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(betweenTime);
        }

        instance.currentPopUp = null;
        instance.runningDisplay = null;
    }

    // Disabling tips when changing from one tip to the next within the same scene
    // there really should only be one tip 
    private void DisablePreviousTip()
    {
        //foreach (PopUp tip in instance.tips)
        //{
        //    if (tip.IsShowing())
        //    {
        //        tip.Close();
        //        tip.transform.parent = gameObject.transform;
        //    }
        //}
        if (instance.currentPopUp != null && instance.runningDisplay != null)
        {
            PopUp tip = instance.currentPopUp;
            tip.Close();
            tip.transform.parent = gameObject.transform;
            instance.currentPopUp = null;
            StopCoroutine(instance.runningDisplay);
            instance.runningDisplay = null;

        }

    }

    private void CloseRunningDisplay()
    {
        if (instance.runningDisplay != null && instance.currentPopUp != null)
        {
            // Reassigning the PopUp to be TipManager child
            instance.currentPopUp.transform.parent = gameObject.transform;
            instance.currentPopUp.Close();
            instance.currentPopUp = null;
            StopCoroutine(instance.runningDisplay);
            instance.runningDisplay = null;
        }
    }

    // Recall our PopUp if we are changing scenes but still have PopUp displaying
    void SceneChangeCoroutine(Scene current)
    {
        CloseRunningDisplay();

        foreach (PopUp tip in instance.tips)
        {
            if (tip.IsShowing())
            {
                tip.Close();
                tip.transform.parent = gameObject.transform;
            }
        }
        StopAllCoroutines();

    }

    //void StopDisplay (Scene scene, LoadSceneMode loadSceneMode)
    //{



    //}
}
