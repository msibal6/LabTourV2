using UnityEngine;
using UnityEngine.UI;


public class TaskLog : MonoBehaviour
{
    public Image background;
    public Task[] tasks;
   
    private void Update()
    {
        if (DialogueManager.instance.controlViewed == true)
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



        if (DialogueManager.instance.anxiousViewed == true)
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

        if (DialogueManager.instance.controlOverlayChecked)
        {
            tasks[3].CheckOff();
        }

        if (DialogueManager.instance.anxiousOverlayChecked)
        {
            tasks[7].CheckOff();
        }

    }

    public void CheckOverlays()
    {
        if (!DialogueManager.instance.controlOverlayChecked && MySceneManager.instance.picturesTaken.Contains("Control Red")
            && MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            DialogueManager.instance.controlOverlayChecked = true;
            tasks[3].CheckOff();

        }

        if (!DialogueManager.instance.anxiousOverlayChecked && MySceneManager.instance.picturesTaken.Contains("Stress Red")
        && MySceneManager.instance.picturesTaken.Contains("Stress Blue"))
        {
            DialogueManager.instance.anxiousOverlayChecked = true;
            tasks[7].CheckOff();
        }
    }
}
