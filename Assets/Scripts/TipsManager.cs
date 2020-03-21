using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipsManager : MonoBehaviour
{
    public static TipsManager instance;

    public InteractionController player;
    public Coroutine runningCoroutine;
    public Text[] tips;
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




    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += SceneChangeCoroutine; 
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(instance.introduced == false)
        {

            instance.runningCoroutine = StartCoroutine(DisplayTexts(0, 3, 0.5f));

            instance.introduced = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pcChecked == false && player.GetRaycastHit().collider.name == "Monitor")
        {
            if (instance.runningCoroutine != null)
            {
                StopCoroutine(instance.runningCoroutine);
                instance.runningCoroutine = null;
            }
            pcChecked = true;
            instance.runningCoroutine = StartCoroutine(DisplayTexts(4, 5, 0.5f));
        }
    }

    IEnumerator DisplayText (Text displayText, float waitTime)
    {
        displayText.gameObject.SetActive(true);
        displayText.enabled = true;
        yield return new WaitForSeconds(waitTime);
        displayText.enabled = false;
    }

    IEnumerator DisplayTexts(int start, int end, float betweenTime)
    {

        foreach (Text tip in instance.tips)
        {
            if (tip.enabled)
            {
                tip.enabled = false;

            } 

        }
        for (int i = start; i <= end; i++)
        {
            Text displayText = instance.tips[i];
            int characters = displayText.text.ToString().Length;
            // 5 is average word length

            float approxWords = characters / 5;

            // 200 is average reading words per minute
            // 60 seconds in a minute
            // adjust waitTime to length of string
            float waitTime = approxWords / 250 * 60;
            displayText.gameObject.SetActive(true);
            displayText.enabled = true;
            yield return new WaitForSeconds(waitTime);
            displayText.enabled = false;
            yield return new WaitForSeconds(betweenTime);
        }
        instance.runningCoroutine = null;

    }

    void SceneChangeCoroutine(Scene current)
    {
        
        StopCoroutine(instance.runningCoroutine);
        instance.runningCoroutine = null;

    }


}
