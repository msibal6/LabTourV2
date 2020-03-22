using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipsManager : MonoBehaviour
{
    public static TipsManager instance;

    public Coroutine runningCoroutine;
    public PopUp[] tips;
    public bool introduced;
    public bool slidesChecked;
    public bool micChecked;
    public bool pcChecked;
    public bool anxiousPicked;
    public bool controlPiecked;
    public bool anxiousViewed;
    public bool controlViewed;
    public bool filterViewed;
    public bool noFilterViewed;
    public bool filterPicTaken;
    public bool noFilterPicTaken;

    private Canvas tipsArea;
    private PopUp currentPopUp;




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
            instance.runningCoroutine = StartCoroutine(DisplayTips(0, 3, 0.5f));
            instance.introduced = true;
        }

        SceneManager.sceneUnloaded += SceneChangeCoroutine;
        SceneManager.sceneLoaded += UpdateDisplay;



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
                break;

            default:
                break;
        }

    }

    private void ShowLabRoomTips()
    {
        InteractionController tempPlayer = FindObjectOfType<InteractionController>();

        // Show computer tips
        if (instance.pcChecked == false && tempPlayer.GetRaycastHit().collider != null && tempPlayer.GetRaycastHit().collider.name == "Monitor")
        {
            if (instance.runningCoroutine != null)
            {
                StopCoroutine(instance.runningCoroutine);
                instance.runningCoroutine = null;
            }
            instance.pcChecked = true;
            instance.runningCoroutine = StartCoroutine(DisplayTips(4, 5, 0.5f));
        }
    }




    void SceneChangeCoroutine(Scene current)
    {
        if (instance.runningCoroutine != null)
        {
            instance.currentPopUp.transform.parent = gameObject.transform;
            StopCoroutine(instance.runningCoroutine);
            instance.runningCoroutine = null;
        }
    }

    void UpdateDisplay(Scene scene, LoadSceneMode loadSceneMode)
    {
        instance.tipsArea = GetComponent<Canvas>();
        print(instance.tipsArea);
    }

    public IEnumerator DisplayTip(PopUp tipToShow, float waitTime)
    {
        instance.tipsArea = GetComponent<Canvas>();

        // Disabling previous tips
        foreach (PopUp tip in instance.tips)
        {
            if (tip.IsShowing())
            {
                tip.Close();
                tip.transform.parent = gameObject.transform;
            }
        }

        tipToShow.transform.parent.SetParent(instance.tipsArea.transform);
        tipToShow.gameObject.SetActive(true);

        // Showing tip 
        tipToShow.Display();
        yield return new WaitForSeconds(waitTime);

        // Closing tip 
        tipToShow.Close();
    }

    public IEnumerator DisplayTips(int start, int end, float betweenTime)
    {
        instance.tipsArea = GetComponent<Canvas>();

        // Unenabling any text from previous tip
        foreach (PopUp tip in instance.tips)
        {
            if (tip.IsShowing())
            {
                tip.Close();
                tip.transform.parent = gameObject.transform;
            }
        }

        for (int i = start; i <= end; i++)
        {

            // Calculations for how long to display text 
            PopUp tip = instance.tips[i];
            int characters = tip.text.text.Length;
            float words = characters / 5; // Average number of characters in word
            float waitTime = words / 250 * 60; // Average reading speed, seconds in minute

            instance.tipsArea = FindObjectOfType<Canvas>();


            // Activation
            tip.gameObject.SetActive(true);
            tip.transform.parent = instance.tipsArea.transform;
            instance.currentPopUp = tip;
            tip.Display();
            yield return new WaitForSeconds(waitTime);

            // De-activation
            tip.Close();
            tip.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(betweenTime);
        }

        instance.runningCoroutine = null;
    }
}
