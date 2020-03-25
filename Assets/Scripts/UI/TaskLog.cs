using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskLog : MonoBehaviour
{
    public Image background;
    public Task[] tasks;
    // 
    private bool controlOverlayChecked;
    private bool anxiousOverlayChecked;


    // TODO check off looking at the correct overlays



    private void Update()
    {
        if (TipsManager.instance.controlViewed == true)
        {
            tasks[0].CheckOff();
        }

        if (MySceneManager.instance.picturesTaken.Contains("Control Red"))
        {
            tasks[1].CheckOff();

        }

        if (MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            tasks[2].CheckOff();
        }



        if (TipsManager.instance.anxiousViewed == true)
        {
            tasks[4].CheckOff();
        }

        if (MySceneManager.instance.picturesTaken.Contains("Stress Red"))
        {
            tasks[5].CheckOff();
        }

        if (MySceneManager.instance.picturesTaken.Contains("Stress Blue"))
        {
            tasks[6].CheckOff();
        }


    }

    public void CheckOverlays()
    {
        if (MySceneManager.instance.picturesTaken.Contains("Control Red")
            && MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            tasks[3].CheckOff();

        }

        if (MySceneManager.instance.picturesTaken.Contains("Stress Red")
        && MySceneManager.instance.picturesTaken.Contains("Stress Blue"))

        {
            tasks[7].CheckOff();
        }
    }
}
