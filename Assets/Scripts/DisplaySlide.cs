using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySlide : MonoBehaviour
{
   
    public Sprite[] slidePictures;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (MySceneManager.instance.slideDisplayed)
        {
            case "brain slide (1)":
                gameObject.GetComponent<Image>().sprite = slidePictures[1];

                // add cases where each of the filters are one
                break;
            case "brain slide (2)":
                gameObject.GetComponent<Image>().sprite = slidePictures[2];
                break;
            case "brain slide (3)":
                gameObject.GetComponent<Image>().sprite = slidePictures[3];
                break;
            default:
                gameObject.GetComponent<Image>().sprite = slidePictures[0];
                break;
        }


    }
}
