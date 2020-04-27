using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FileWindow : MonoBehaviour
{
    public Image fileBackground;
    // make this exitButton a mutton
    public Mutton exitMutton;
   
    public ImageFile[] imageFiles;


    // Start is called before the first frame update
    void Start()
    {
        fileBackground.enabled = false;
        // TODO
        // Make a button class that 
        exitMutton.Disable();
    }

    public void OpenFileWindow()
    {
        fileBackground.enabled = true;
        exitMutton.Enable();
        ShowPictures();

    }

    private void ShowPictures()
    {
        // HACK FUTURE
        // Just show pictures that they have taken
        if (MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            //files[0].Display();
            imageFiles[0].ShowIcon();
        }
        if (MySceneManager.instance.picturesTaken.Contains("Control Red"))
        {
            //files[1].Display();
            imageFiles[1].ShowIcon();

        }
        if (MySceneManager.instance.picturesTaken.Contains("Stress Blue"))
        {
            //files[2].Display();
            imageFiles[2].ShowIcon();

        }
        if (MySceneManager.instance.picturesTaken.Contains("Stress Red"))
        {
            //files[3].Display();
            imageFiles[3].ShowIcon();

        }
    }

    public void CloseFileWindow()
    {
        fileBackground.enabled = false;
        exitMutton.Disable();
        ClosePictures();


    }

    private void ClosePictures()
    {
        foreach (ImageFile imageFile in imageFiles)
        {
            if (imageFile.IconShowing == true)
            {
                imageFile.HideIcon();
            }
        }
    }
}
