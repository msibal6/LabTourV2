using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{

    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);

    }

    public void ButtonTakePicture()
    {
        if (MySceneManager.instance.slideDisplayed != "")
        {
            string tempMicroscopeImage = GameObject.Find("Microscope Image").GetComponent<Image>().sprite.name;
            if (!MySceneManager.instance.picturesTaken.Contains(tempMicroscopeImage))
            {
                print("took picture of " + tempMicroscopeImage);
                MySceneManager.instance.picturesTaken.Add(tempMicroscopeImage);
            }
            else
            {
                print(tempMicroscopeImage);
                print("you already took this picture");
            }

        }
        else
        {
            Debug.Log("You dont't want to take a picture of nothing");
        }

    }
}
