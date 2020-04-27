using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OverlayWindow : MonoBehaviour
{
    public Image fileBackground;
    public Mutton exitMutton;
    public ImageFile[] overlayFiles;

    // Start is called before the first frame update
    void Start()
    {
        fileBackground.enabled = false;
        // TODO
        // Make a button class that 
        exitMutton.Disable();
        // We already that PopUps start out disabled;
    }

    public void OpenWindow()
    {
        fileBackground.enabled = true;
        exitMutton.Enable();
        showOverlays();

    }

    private void showOverlays()
    {
        // HACK FUTURE
        // Just show pictures that they have taken
        if (MySceneManager.instance.picturesTaken.Contains("Control Blue")
            && MySceneManager.instance.picturesTaken.Contains("Control Red"))
        {
            //files[0].Display();
            overlayFiles[0].ShowIcon();
        }

        if (MySceneManager.instance.picturesTaken.Contains("Stress Blue")
            && MySceneManager.instance.picturesTaken.Contains("Stress Red"))
        {
            //files[1].Display();
            overlayFiles[1].ShowIcon();

        }

    }

    public void CloseWindow()
    {
        fileBackground.enabled = false;
        exitMutton.Disable();
        CloseFiles();


    }

    private void CloseFiles()
    {
        foreach (ImageFile overlayFile in overlayFiles)
        {
            if (overlayFile.IconShowing == true)
            {
                overlayFile.HideIcon();
            }
        }
    }
}
