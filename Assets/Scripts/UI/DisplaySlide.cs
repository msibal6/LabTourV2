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
                    // Control Blue
                    gameObject.GetComponent<Image>().sprite = slidePictures[1];
                }
                else
                {
                    // Control Red
                    gameObject.GetComponent<Image>().sprite = slidePictures[2];
                }
                break;

            case "Anxious Mouse":
                if (toggleFilter.isOn)
                {
                    // Stress Blue
                    gameObject.GetComponent<Image>().sprite = slidePictures[3];
                }
                else
                {
                    // Stress Red
                    gameObject.GetComponent<Image>().sprite = slidePictures[4];

                }

                break;
            default:
                // Displaying nothing
                gameObject.GetComponent<Image>().sprite = slidePictures[0];
                break;
        }
    }
}
