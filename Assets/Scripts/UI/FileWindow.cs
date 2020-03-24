using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FileWindow : MonoBehaviour
{
    public Image fileBackground;
    public Button exitButton;
    // HACK FUTURE make a file class
    public PopUp[] files;

    // Start is called before the first frame update
    void Start()
    {
        fileBackground.enabled = false;
        // TODO
        // Make a button class that 
        exitButton.enabled = false;
        exitButton.GetComponentInChildren<Text>().enabled = false;
        exitButton.GetComponent<Image>().enabled = false;
        // We already that PopUps start out disabled;
    }

    public void OpenFileWindow()
    {
        fileBackground.enabled = true;
        exitButton.enabled = true;
        exitButton.GetComponentInChildren<Text>().enabled = true;
        ShowPictures();

    }

    private void ShowPictures()
    {
        // HACK FUTURE
        // Just show pictures that they have taken
        if (MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            files[0].Display();
        }
        if (MySceneManager.instance.picturesTaken.Contains("Control Red"))
        {
            files[1].Display();
        }
        if (MySceneManager.instance.picturesTaken.Contains("Stress Blue"))
        {
            files[2].Display();
        }
        if (MySceneManager.instance.picturesTaken.Contains("Stress Red"))
        {
            files[3].Display();
        }
    }

    public void CloseFileWindow()
    {
        fileBackground.enabled = false;
        exitButton.enabled = false;
        exitButton.GetComponentInChildren<Text>().enabled = false;
        ClosePictures();


    }

    private void ClosePictures()
    {
        foreach (PopUp file in files)
        {
            if (file.IsShowing())
            {
                file.Close();
            }
        }
    }
}
