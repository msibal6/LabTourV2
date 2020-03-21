using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySlide : MonoBehaviour
{
    public Toggle toggleFilter;
    public Sprite[] slidePictures;


    // Update is called once per frame
    void Update()
    {
        switch (MySceneManager.instance.slideDisplayed)
        {

            case "Control Mouse":

                if (toggleFilter.isOn)
                {
                    // Control Red
                    gameObject.GetComponent<Image>().sprite = slidePictures[2];
                }
                else
                {
                    // Control Blue
                    gameObject.GetComponent<Image>().sprite = slidePictures[1];

                }
                break;

            case "Anxious Mouse":
                if (toggleFilter.isOn)
                {
                    // Stress Red
                    gameObject.GetComponent<Image>().sprite = slidePictures[4];
                }
                else
                {
                    // Stress Blue
                    gameObject.GetComponent<Image>().sprite = slidePictures[3];
                }

                break;
            default:
                // Displaying nothing
                gameObject.GetComponent<Image>().sprite = slidePictures[0];
                break;
        }
    }
}
