using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeController : MonoBehaviour
{


    private GameObject placedSlide;
    public Transform placePoint;



    // Start is called before the first frame update
    void Start()
    {
        if (MySceneManager.instance)
        {
            if(MySceneManager.instance.slideDisplayed != "")
            Place(GameObject.Find(MySceneManager.instance.slideDisplayed));
        }

    }



    public void Place(GameObject slideToPlace)
    {

        placedSlide = slideToPlace;
        placedSlide.transform.position = placePoint.position;

        SlideController tempSlide = placedSlide.gameObject.GetComponent<SlideController>();
        tempSlide.SetHolder(gameObject);
        MySceneManager.instance.slideDisplayed = placedSlide.gameObject.name;

    }

    public void Release()
    {
        placedSlide = null;
        MySceneManager.instance.slideDisplayed = "";
    }

    public bool ContainSlide()
    {
        return (placedSlide != null);
    }

    public string GetSlideName()
    {
        if (placedSlide != null)
        {
            return placedSlide.gameObject.name;
        }
        return "";
    }
    


}
